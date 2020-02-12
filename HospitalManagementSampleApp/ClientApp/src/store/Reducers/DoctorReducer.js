import ActionTypes from '../Actions/ActionTypes';
import initialState from '../State/initialState';
import updateObject from '../utils/utils';



export default (state=initialState,action)=>{

    switch(action.type){

       case ActionTypes.GET_DOCTORS:
            return fetchDoctors(state, action);
        case ActionTypes.GET_DOCTORS_SUCCESS:
            return fetchDoctorsSuccess(state, action);
        
        case ActionTypes.GET_PATIENTS_FAILURE:
            return fetchDoctorsFailure(state, action);

        default:
            return state;
    }
}


/////////

const fetchDoctors=(state, action)=>{

    return updateObject(state, {
        doctors:{}
    })

}


const fetchDoctorsSuccess=(state,action)=>{

    return updateObject(state,{
            doctors: action.doctors
    })
}

const fetchDoctorsFailure=(state,action)=>{

    return state
}