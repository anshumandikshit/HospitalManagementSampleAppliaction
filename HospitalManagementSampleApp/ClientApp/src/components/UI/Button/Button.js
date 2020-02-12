import React from 'react';
import classes from '../Button/button.css';

const button = props => {
    
    return(

        <button 
    disabled={props.disable}
    onClick = { props.clicked }
    className = { [classes.Button, classes[props.btnType]].join(' ') }>
    { props.children }
    </button>
    )
}

    
    


export default button;