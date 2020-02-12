import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'react-router-redux';
import { BrowserRouter } from "react-router-dom";
import { createBrowserHistory } from 'history';
import configureStore from './store/configureStore';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

// Create browser history to use in the Redux store


// Get the application-wide store instance, prepopulating with state from the server where available.

// const store = ConfigureStore();

const rootElement = document.getElementById('root');

const store = configureStore();

ReactDOM.render(
    <Provider store={store}>
      <BrowserRouter >
      <App />
    </BrowserRouter>
    </Provider>
  ,
  rootElement);

registerServiceWorker();
