import React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import classes from './NavMenu.css';

export default class NavMenu extends React.Component {
  constructor (props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }
  toggle () {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  render () {
   let linkData =[
     {
       linkUrl: "patients",
       linkName:"Patient"
     },
     {
      linkUrl: "doctors",
      linkName:"Doctors"
      },
    
    
   ]

    return (
      <header>
        <nav className="navbar navbar-dark bg-dark" style={{color:"white"}}>
        <Link to={`/`} style={{margin:"5px",padding:"1px",color:"white",textDecoration:"none"}}>Home</Link>
        
        <div className="d-flex">
         
         {
           linkData.map(data=>{
             return(
             <Link to={`/${data.linkUrl}`} style={{margin:"5px",padding:"1px",color:"white",textDecoration:"none"}}>{data.linkName}</Link>
              
             )
           })
         }
          
        </div>
        </nav>
        
      </header>
    );
  }
}
