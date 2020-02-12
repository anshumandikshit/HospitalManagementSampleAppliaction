import React, { Component } from 'react';
import { connect } from 'react-redux';
import {getPatients} from '../store/Actions/rootActionCreators'


class Doctors extends Component{

    componentDidMount(){
      // this.props.fetchDoctors();
    }
    render(){

        return(

          (!this.props.doctors.listOfData)? <div><h>Sorry,No Doctors Available</h></div>:(
            <table>
              
            <thead>
            <tr>
            <th>DoctorId</th>
            <th>DoctorsName</th>
                       
            </tr>
            </thead>
            <tbody>
              {
                this.props.doctors.listOfData.map(data=>{
                  return(
                    <tr  key={data.doctorId}>
                                
                  <td>{data.doctorId}</td>
                  <td>{data.doctorName}</td>
                    </tr>

                  )
              })
              }
            </tbody>
            </table>
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
        
        fetchDoctors: () => dispatch(getPatients())
    }
  }

export default connect(mapStateToProps,null) (Doctors);