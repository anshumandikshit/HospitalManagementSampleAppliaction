import React, { Component } from 'react';
import { Container, Form } from 'reactstrap';
import NavMenu from './NavMenu';
import { getDoctors } from '../store/Actions/rootActionCreators';
import { connect } from 'react-redux';


class Layout extends Component{

  componentDidMount(){
     this.props.fetchDoctors();
  }

  render(){
    return(
      <div>
      <NavMenu />
      <Container>
        {this.props.children}
      </Container>
      </div>
    )
      
  }

}

const mapStateToProps = state => {
  return {
    doctors: state.doctorReducer.doctors,
      
  }
}

const mapDispatchToProps = dispatch => {
  return {
      
      fetchDoctors: () => dispatch(getDoctors())
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(Layout); 