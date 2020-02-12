import React,{ Component } from "react";
import Input from './UI/Input/Input';
import Button from './UI/Button/Button';
import classes from '../components/UI/addPatients.css';
import { connect } from 'react-redux';
import {addPatient,getPatients,updatePatient} from '../store/Actions/rootActionCreators'


class AddPatients extends Component{
    state={
        canAdd: false,
        fields: {
            name: { ...this.generateInput('input', {
                id: "name",
                type: "text",
                name: "name",                
                label: "Name",
                placeholder: "Patient name.."
            }),
                validation: {
                    required: true,
                    maxLength: 20
                },
                errorMsg: 'This field is required',
                valid: false
            },
            
            patientSex:{... this.generateInput('select', {
                id: "patientSex", 
                name: "patientSex",                    
                label: "Patient Sex",
                options: [
                    {
                        value: '1',
                        displayValue: 'Male'
                    },
                    {
                        value: '2',
                        displayValue: 'Female'
                    },
                    {
                        value: '3',
                        displayValue: 'Other'
                    }
                ],
                               
            }),
            validation: {
                required: false,
                
            },

            valid: true
        
            },

            roomType:{... this.generateInput('select', {
                id: "RoomType", 
                name: "RoomType",                    
                label: "Room Type",
                options: [
                    {
                        value: '1',
                        displayValue: 'SingleSeated'
                    },
                    {
                        value: '2',
                        displayValue: 'TwoSeated'
                    },
                    {
                        value: '3',
                        displayValue: 'VIP'
                    }
                ],
                               
            }),
            validation: {
                required: true,
                
            },
            errorMsg: 'This field is required' ,
            valid: true
            },
            estimatedEndDate:{
                ...this.generateInput('date',{
                    id: "estimatedEndDate", 
                    name: "estimatedEndDate",                    
                    label: "EstimatedEnd Date",
                }),
                validation: {
                    required: false,
                    
                },
                errorMsg: 'This field is required' ,
                valid: true
            },

            schedulingStatus:{... this.generateInput('select', {
                id: "schedulingStatus", 
                name: "schedulingStatus",                    
                label: "Scheduling Status",
                options: [
                    {
                        value: '1',
                        displayValue: 'Planned'
                    },
                    {
                        value: '2',
                        displayValue: 'InProgress'
                    },
                    {
                        value: '3',
                        displayValue: 'Finished'
                    }
                ],
                               
            }),
            validation: {
                required: true,
                
            },
            errorMsg: 'This field is required' ,
            valid: true
            },

            statusDescription: { ...this.generateInput('textarea', {
                id: "statusDescription",
                type: "textarea",
                name: "statusDescription",                
                label: "StatusDescription",
                placeholder: "Add summary"
            }),
                validation: {
                    required: true,
                    minLength:3
                },
                errorMsg: 'This field is required',
                valid: false
            },

            
        }
    }


    generateInput(inputtype, config) {

        let value = '';
        if (inputtype === 'select') value = config.options[0].value;
        return { inputtype, config, value, touched: false };
    }


    validateInput(value, rules) {
        let validationArray = [];

        if (rules) {

            if (rules.required) {
                validationArray.push((value.trim() !== ''))
            }

            if (rules.minLength) {
                validationArray.push((value.length >= rules.minLength));
            }

            if (rules.maxLength) {
                validationArray.push((value.length <= rules.maxLength));
            }
        } else {
            validationArray.push(true);
        }

        return validationArray.every(entry => entry);
    }


    handleInput = (e, field) => {
        const updatedValue = e.target.value;
        const updatedFields = { ...this.state.fields };
        const updatedField = { ...this.state.fields[field] };

        updatedField.value = updatedValue;

        updatedField.valid = this.validateInput(updatedValue, updatedField.validation);
        updatedField.touched = true;

        updatedFields[field] = updatedField;
    
        const canAdd = this.canAdd(updatedFields);
        
        this.setState({ fields: updatedFields, canAdd });        
    }


    canAdd = (fields) => {
        const checkValidation = [];

        for (let field in fields) {
                      
                if (fields[field].touched) {
                    
                        checkValidation.push(fields[field].valid);         
                     
                } else {
                    checkValidation.push(fields[field].valid);                   
                }
             
        }
        return checkValidation.every(entry => entry);
    }

    AddHadler=(event)=>{
        event.preventDefault();
        if(this.props.match.params.id==0){
            let addPatient={
                "patientName":this.state.fields.name.value,
                "patientSex":this.state.fields.patientSex.value,
                "doctorRequests":[{"DoctorId":this.state.fields.doctors.value}],
                "roomNameId":this.state.fields.roomType.value,
                "StudyRequests":[{
                    "Descriptions":this.state.fields.statusDescription.value,
                    "StudyStatusId":this.state.fields.schedulingStatus.value,
                    "DoctorId":this.state.fields.doctors.value,
                    "EstimatedEndTime":this.state.fields.estimatedEndDate.value
                }]
            }
           

        this.props.addPatient(addPatient);
        this.props.getPatients();
        }
       else{
           //Update Patient call 
           let updatePatient={
               "patientId":this.props.match.params.id,
            "patientName":this.state.fields.name.value,
            "patientSex":this.state.fields.patientSex.value,
            "doctorRequests":[{"DoctorId":this.state.fields.doctors.value}],
            "roomNameId":this.state.fields.roomType.value,
            "StudyRequests":[{
                "Descriptions":this.state.fields.statusDescription.value,
                "StudyStatusId":this.state.fields.schedulingStatus.value,
                "DoctorId":this.state.fields.doctors.value,
                "EstimatedEndTime":this.state.fields.estimatedEndDate.value
            }]
        }
        this.props.updatePatient(updatePatient);
        this.props.getPatients();

       }
        
        this.props.history.replace('/patients');
    }

    

    componentDidMount(){

                this.setState(prevState=>{
                    let stateTobeUpdated ={...prevState}
                    stateTobeUpdated.fields.doctors={... this.generateInput('select', {
                    id: "doctors", 
                    name: "doctors",                    
                    label: "Select Doctors",
                    options:this.props.doctors.listOfData.map(({doctorId,doctorName})=>{return {value:doctorId,displayValue:doctorName}}),
                }),
                
                validation: {
                    required: true,
                    
                },
                errorMsg: 'This field is required' ,
                valid: true
            }
            return{fields:stateTobeUpdated.fields};
            })

        if(this.props.match.params.id>0){
           let patientsData={...this.props.patients}
          let patient= patientsData.listOfData.filter(p=>p.patientId==this.props.match.params.id);

          
           this.setState(prevState=>{

                let stateTobeUpdated ={...prevState};
                const {fields}=stateTobeUpdated;
                fields.name.value=patient[0].patientName;
                fields.name.valid=true;
                fields.doctors.value=patient[0].doctorDetails[0].doctorId;
                fields.statusDescription.value=patient[0].studyDetails[0].description;
                fields.schedulingStatus.value=patient[0].studyDetails[0].studyStatusId;
                fields.roomType.value=patient[0].roomTypeId;
                fields.patientSex.value=patient[0].patientSexId;
                stateTobeUpdated.fields={...fields};
                
                return{fields:stateTobeUpdated.fields}
           })

        }
       
       
    }

    render(){
        const { fields } = this.state;
        const {id}=this.props.match.params;
        
        return(
            <div className="container" style={{width:"50%"}}>

            <div className={classes.AddPatient}>
                <h4>{(id==0)?`Add Patient`:`Update Patient`} Details</h4>
                <form action="">
                    
                { Object.keys(fields).map(field => (
                    <div className="form-group">
                    <Input
                        key = { fields[field].config.id }
                        { ...fields[field] }
                        changed = { e => this.handleInput(e, field) }
                        shouldValidate = { fields[field].validation } 
                        error = {(fields[field].touched)? (fields[field].errorMsg ? fields[field].errorMsg : null):null }                      
                    /> 
                    </div>           
                )) }

                    <Button
                    btnType = { this.state.canAdd ? 'Success' : 'Danger' }
                    disable={!this.state.canAdd}                    
                    clicked = { this.state.canAdd ? this.AddHadler : null }>{(id==0)?`Add Patient`:`Update Patient`}</Button>
                </form>
            </div>
            </div>
        );
        
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
        
        addPatient: (patient) => dispatch(addPatient(patient)),
        getPatients:()=>dispatch(getPatients()),
        updatePatient:(patient)=>dispatch(updatePatient(patient))
    }
  }

  
  
export default connect(mapStateToProps,mapDispatchToProps)(AddPatients);
