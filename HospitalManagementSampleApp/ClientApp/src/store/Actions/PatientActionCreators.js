import  ActionTypes from './ActionTypes';
import axios from '../../Axios/axios-hospital';

export const getPatients = ()=>{
    return dispatch =>{

        dispatch(fetchPatients());

        axios
        .get('/Patient/getAllLists')
        .then(response => {
            if (response.data) {
                
            dispatch(fetchPatientsSuccess(response.data));
            } else {
                throw new Error('Network Error: could not fetch Patients.');
            }
        })
        .catch(error => {
            dispatch(fetchPatientsFailure(error))
        })        
    }
    
}



/////////////////////// These are the functions which will provide you the dispatcing Action objects .
function fetchPatientsSuccess(patients) {
    return {
        type:ActionTypes.GET_PATIENTS_SUCCESS,
        patients:patients
    }    
}

function fetchPatientsFailure(error){

    return {
        type:ActionTypes.GET_PATIENTS_FAILURE,
        error:error
    }

}

function fetchPatients(){
    return{
        type:ActionTypes.GET_PATIENTS
    }
}




//Add Patient

export const addPatient = (patient)=>{
    return dispatch =>{

        axios
        .post('/Patient/addPatient',patient)
        .then(response => {
            if (response.data.isSuccess) {
              
                addPatientsSuccess(response.data)
            
            } else {
                throw new Error('Network Error: could not add Patient.');
            }
        })
        .catch(error => {
            dispatch(addPatientsFailure(error))
        })        
    }
    
}

function addPatientsSuccess(newPatient){

    return {
        type:ActionTypes.ADD_PATIENT,
        newPatient:newPatient
    }

}



function addPatientsFailure(error){

    return {
        type:ActionTypes.ADD_PATIENT_FAILURE,
        error:error
    }

}


///////UpdatePatient
export const updatePatient = (patient)=>{
    return dispatch =>{

        axios
        .post('/Patient/updatePatient',patient)
        .then(response => {
            if (response.data) {
                
                updatePatientsSuccess()
            
            } else {
                throw new Error('Network Error: could not add Patient.');
            }
        })
        .catch(error => {
            dispatch(addPatientsFailure(error))
        })        
    }
    
}


function updatePatientsSuccess(){

    return {
        type:ActionTypes.UPDATE_PATIENT,
        
    }

}



function addPatientsFailure(error){

    return {
        type:ActionTypes.UPDATE_PATIENTT_FAILURE,
        error:error
    }

}
