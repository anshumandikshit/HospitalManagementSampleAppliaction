using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Domain.DTOs.RequestDTOs;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Domain.Interfaces.Repositories;
using HospitalManagement.Domain.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HospitalManagement.Domain.DTOs.ResponseDTOs;
using Microsoft.EntityFrameworkCore;


namespace HospitalManagementSampleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseApiController
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDoctorPatientRepository _doctorPatientRepository;
        private readonly IStudyRepository _studyRepository;

        public PatientController(IPatientRepository patientRepository, IRoomRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper, IDoctorPatientRepository doctorPatientRepository, IStudyRepository studyRepository)
        {
            _patientRepository = patientRepository;
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _doctorPatientRepository = doctorPatientRepository;
            _studyRepository = studyRepository;
        }

        [HttpGet]
        [Route("getAllLists")]
        public async Task<IActionResult> GetAllLists()
        {



            var resultModel = new ServiceResultModel<PatientResponseDto> { IsSuccess = false, Errors = new List<string>() };
            var patientDetails = await _patientRepository.FindWithIncludeAsync<PatientResponseDto>(null,
                null,
                pt => pt.Include(p => p.DoctorPatients).Include(p => p.Studies).ThenInclude(x => x.Doctor),
                null,
                null,
                true,
                pt => new PatientResponseDto
                {
                    PatientId = pt.PatientId,
                    PatientName = pt.PatientName,
                    DoctorDetails = pt.DoctorPatients.Select(dp => new DoctorResponseDto { DoctorId = dp.Doctor.DoctorId, DoctorName = dp.Doctor.DoctorName }).ToList(),
                    StudyDetails = pt.Studies.Select(s => new StudyResponseDto { StudyId = s.StudyId, Description = s.Descriptions, StudyStatusId = s.StudyStatusId, DoctorName = s.Doctor.DoctorName, StartDate = s.PlannedStartTime, EstimatedEndDate = s.EstimatedEndTime }).ToList(),
                    PatientSexId = pt.PatientSexId,
                    RoomTypeId = pt.Room.RoomTypeId

                });
            if (patientDetails != null)
            {
                resultModel.IsSuccess = true;
                resultModel.ListOfData = patientDetails;
                return Ok(resultModel);
            }

            return Ok("No Patient Details found");
        }

        [HttpPost]
        [Route("updatePatient")]
        public async Task<IActionResult> UpdatePatient([FromBody] PatientRequestDto patientRequestDto)
        {
            if (String.IsNullOrEmpty(patientRequestDto.StudyRequests[0].EstimatedEndTime))
            {
                patientRequestDto.StudyRequests[0].EstimatedEndTime = null;
            }

            var patientDetails = await _patientRepository.FirstOrDefaultWithIncludeAsync(p => p.PatientId == patientRequestDto.PatientId,
                pt => pt.Include(p => p.DoctorPatients).Include(p => p.Room).Include(p => p.Studies).ThenInclude(x => x.Doctor));

            
            if (patientDetails == null)
            {
                return BadRequest("UserDetails does not exsists");
            }

         var studyDetails= await _studyRepository.FirstOrDefaultWithIncludeAsync(s => s.PatientId == patientDetails.PatientId);
            studyDetails.StudyStatusId = patientRequestDto.StudyRequests[0].StudyStatusId;
            studyDetails.Descriptions = patientRequestDto.StudyRequests[0].Descriptions;
            studyDetails.EstimatedEndTime = patientRequestDto.StudyRequests[0].EstimatedEndTime;
            patientDetails.PatientName = patientRequestDto.PatientName;
            patientDetails.PatientSexId = patientRequestDto.PatientSex;
            patientDetails.Room.RoomTypeId = patientRequestDto.RoomNameId;

          var doctorPatientDetails= _doctorPatientRepository.FirstOrDefault(d => d.PatientId == patientDetails.PatientId);
            doctorPatientDetails.DoctorId = patientRequestDto.DoctorRequests[0].DoctorId;

            _doctorPatientRepository.Edit(doctorPatientDetails);
            _studyRepository.Edit(studyDetails);
            _patientRepository.Edit(patientDetails);
           var saved= await _unitOfWork.CommitAsync();
            if (saved > 0)
            {
                return Ok("Successfully Modified ");
            }
            
            return BadRequest("Could not modify ");
        }



        [HttpPost]
        [Route("addPatient")]
        public async Task<IActionResult> AddPatient([FromBody] PatientRequestDto patientRequestDto)
        {
            if (String.IsNullOrEmpty(patientRequestDto.StudyRequests[0].EstimatedEndTime))
            {
                patientRequestDto.StudyRequests[0].EstimatedEndTime = null;
            }
            var resultModel = new ServiceResultModel<Patient> { IsSuccess = false, Errors = new List<string>() };
            var patientExsists = _patientRepository.Any(p => p.PatientName == patientRequestDto.PatientName);
            if (patientExsists) return BadRequest("Patient already exsits");


            var newPatient = _patientRepository.Add(new Patient
            {
                PatientName = patientRequestDto.PatientName,
                DOB = patientRequestDto.DOB,
                PatientSexId = patientRequestDto.PatientSex,
                RoomId = (int)patientRequestDto.RoomNameId,

            });


            var saved = (newPatient != null) ? await _unitOfWork.CommitAsync() : 0;

            var newDoctorPatient = _doctorPatientRepository.Add(new DoctorPatient { DoctorId = patientRequestDto.DoctorRequests[0].DoctorId, PatientId = newPatient.PatientId });
            var doctorPatientSaved = (newDoctorPatient != null) ? await _unitOfWork.CommitAsync() : 0;

            var newStudy = _studyRepository.Add(new Study { PatientId = newPatient.PatientId, StudyStatusId = patientRequestDto.StudyRequests[0].StudyStatusId, DoctorId = patientRequestDto.DoctorRequests[0].DoctorId, PlannedStartTime = DateTime.Now.ToShortDateString(), EstimatedEndTime = patientRequestDto.StudyRequests[0].EstimatedEndTime, Descriptions = patientRequestDto.StudyRequests[0].Descriptions });
            var savedStudy = (newStudy != null) ? await _unitOfWork.CommitAsync() : 0;
            var resultPatient = _patientRepository.GetById(newPatient.PatientId);
            if (saved > 0 && doctorPatientSaved > 0 && savedStudy > 0)
            {
                resultModel.IsSuccess = true;
                resultModel.Data = resultPatient;
                return Ok(resultModel);
            }

            return Ok("No Patient Details found");
        }

    }
}