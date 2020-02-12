
import React, { Component } from 'react';

const patientDetails = (props)=>{
    let {id}=props.match.params ;
   
  return(
  <div>{id}</div>
  
  )
}

export default patientDetails;