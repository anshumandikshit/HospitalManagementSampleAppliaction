using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Domain.Interfaces.Repositories;
using HospitalManagement.Domain.ServiceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSampleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : BaseApiController
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorController(IDoctorRepository doctorRepository,IUnitOfWork unitOfWork)
        {
            _doctorRepository = doctorRepository?? throw new ArgumentNullException(nameof(doctorRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        [Route("getAllLists")]
        public async Task<IActionResult> GetAllLists()
        {
            var resultModel = new ServiceResultModel<Doctor> { IsSuccess = false, Errors = new List<string>() };
            var doctordetails = await _doctorRepository.GetAllAsync();
            if (doctordetails != null)
            {
                resultModel.IsSuccess = true;
                resultModel.ListOfData = doctordetails.ToList();
                return Ok(resultModel);
            }

            return Ok("No Doctor Details found");
        }
    }
}