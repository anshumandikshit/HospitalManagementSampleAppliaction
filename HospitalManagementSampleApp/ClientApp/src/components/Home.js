import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
  <div>
    <div className="container-fluid" style={{textAlign:"center",position:"relative",top:"50%",height:"200px",}}></div>
   <h1 style={{textAlign:"center",borderBlockColor:"purple"}}>Hospital Management Application</h1>
  </div>
);

// export default connect()(Home);
export default Home;