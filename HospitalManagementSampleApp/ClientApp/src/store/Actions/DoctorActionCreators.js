import ActionTypes from '../Actions/ActionTypes';
import axios from '../../Axios/axios-hospital'

//asyncFn
export function  getDoctors(){
    return dispatch=>{

        dispatch(fetchDoctors());

        axios
        .get('/Doctor/getAllLists')
        .then(response => {
            if (response.data) {
              
            dispatch(fetchDoctorsSuccess(response.data));
            } else {
                throw new Error('Network Error: could not fetch ingredients.');
            }
        })
        .catch(error => {
            dispatch(fetchDoctorsFailure(error))
        })  
        
    }
}

const fetchDoctors=()=>{
    return{
        type:ActionTypes.GET_DOCTORS
    }
}


function fetchDoctorsSuccess(doctors) {
    return {
        type:ActionTypes.GET_DOCTORS_SUCCESS,
        doctors:doctors
    }    
}

function fetchDoctorsFailure(error){

    return {
        type:ActionTypes.GET_DOCTORS_FAILURE,
        error:error
    }

}