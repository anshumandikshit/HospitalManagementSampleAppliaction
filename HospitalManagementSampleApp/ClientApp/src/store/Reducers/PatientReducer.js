import ActionTypes from '../Actions/ActionTypes';
import initialState from '../State/initialState';
import updateObject from '../utils/utils';

const fetchPatientsSuccess=(state,action)=>{
    return updateObject(state,{
        patients: action.patients
})
}

const fetchPatientsFailure= (state,action)=>{
    return state
}

const fetchPatients=(state,action)=>{
    return updateObject(state, {
        patients:{}
    })
}


const addPatientsSuccess=(state,action)=>{
    return state ;
}


export default (state=initialState,action)=>{

    switch(action.type){

       case ActionTypes.GET_PATIENTS:
            return fetchPatients(state, action);
        case ActionTypes.GET_PATIENTS_SUCCESS:
            return fetchPatientsSuccess(state, action);
        
        case ActionTypes.GET_PATIENTS_FAILURE:
            return fetchPatientsFailure(state, action);
        case ActionTypes.ADD_PATIENT:
            return addPatientsSuccess(state,action);
        case ActionTypes.UPDATE_PATIENT:
            return updatePatientsSuccess(state,action)

        default:
            return state;
    }
}

const updatePatientsSuccess=(state,action)=>{
    return state ;
}



