import React from 'react';
import { Route, Switch } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import patients from './components/Patients';
import doctors from './components/Doctors';
import status from './components/Status';
import NoMatch from './components/nomatch'
import PatientReducer from './store/Reducers/PatientReducer';
import  PatientDetails from './components/PatientDetails';
import AddPatients from "./components/AddPatients"
export default () => (
  <Layout>
    <Switch>
    
    <Route path={ `/patients/:id` } exact component={AddPatients} />
    <Route path='/patients' exact component={patients} />
    
    <Route path='/doctors' component={doctors} />
    
    <Route exact path='/' exact component={Home} />
    <Route component={NoMatch} />
    </Switch>
    
  </Layout>
);
