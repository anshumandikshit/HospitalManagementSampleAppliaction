import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer, routerMiddleware } from 'react-router-redux';
import * as Counter from './Counter';
import * as WeatherForecasts from './WeatherForecasts';
import logger from 'redux-logger';

import PatientReducer from './Reducers/PatientReducer';
import DoctorReducer from './Reducers/DoctorReducer';
import RoomReducer from './Reducers/RoomReducer';
import StatusReducer from './Reducers/StatusReducer';

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const  configureStore = ()=>{
  const rootReducer = combineReducers({
    patientReducer: PatientReducer,
    roomReducer:RoomReducer,
    doctorReducer: DoctorReducer,
    statusReducer:StatusReducer
   
});

  const store= createStore(rootReducer,composeEnhancers(applyMiddleware(logger,thunk)));

  return store ;
}
export default configureStore ;