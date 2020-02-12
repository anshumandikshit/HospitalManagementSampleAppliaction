import React, { Component } from 'react';
import { connect } from 'react-redux';
import {getPatients} from '../store/Actions/rootActionCreators'
import {classes} from '../components/UI/patients.css'
import { Link,withRouter } from 'react-router-dom';
import Button from '../components/UI/Button/Button'


class Patients extends Component{

    componentDidMount(){
       this.props.fetchPatients();
    }

    createDoctorsArray = (doctors)=>{
        let result = doctors.map(({ doctorName }) => doctorName);
        
            return result.join();
    }
    createStudyArray = (studies)=>{
        return studies.map(({description})=>description).join();
    }

    onAddPatientsBtnHandler =()=>{
        this.props.history.push('/patients/0');
    }
    render(){
        return(
                (!this.props.patients.listOfData)?  <h1>Sorry ,No patients found </h1>: (
                    <div className="container-fluid" style={{margin:"10px",padding:"1px"}}>
                        <table>
                            <thead>
                            <tr>
                            <th>patientName</th>
                            <th>DoctorsName</th>
                            <th>Status</th>
                            
                            </tr>
                            </thead>
                        <tbody>
                                { this.props.patients.listOfData.map(data=>{
                                return(
                                <tr  key={data.patientId}>
                                <td><Link to={`patients/${data.patientId}`} >{data.patientName}</Link></td>
                                <td>{this.createDoctorsArray(data.doctorDetails)}</td>
                                    <td>{this.createStudyArray(data.studyDetails)}</td>
                                </tr>
                                )
                            })}
                        </tbody>
                    
                    </table>
                    <div className="container justify-content-center" style={{textAlign:"center"}}>
                            <Button btnType="Success" clicked={this.onAddPatientsBtnHandler}>Add Patients</Button>
                    </div>
                    </div>
                    

                )   
         )
    }
}

const mapStateToProps = state => {
    return {
      doctors: state.doctorReducer.doctors,
        patients: state.patientReducer.patients
    }
  }
  
  const mapDispatchToProps = dispatch => {
    return {
        
        fetchPatients: () => dispatch(getPatients())
    }
  }

export default connect(mapStateToProps,mapDispatchToProps) (withRouter(Patients));