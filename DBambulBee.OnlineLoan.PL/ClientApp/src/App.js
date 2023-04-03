import React, { Component } from 'react';
import { Route } from 'react-router';
import { MasterLayout } from './components/Layout/MasterLayout';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Login } from './components/Pages/Login/Login';
import { Dashboard } from './components/Pages/Dashboard/Dashboard';
import  MainClassification  from './components/Pages/MainClassifications/index';
import Location from './components/Pages/Locations/index';
import SubClassifications from './components/Pages/SubClassifications/index';
import LendingDetails from './components/Pages/LendingDetails/index';

import {
    BrowserRouter as Router,
    Switch,
} from "react-router-dom";

export default class App extends Component {
  static displayName = App.name;


  


  render () {
    return (

        <div>
            <Router>
                <Switch>
                     <Route path="/" component={Login} exact />
                     <Route path="/Login" component={Login} exact />
                     <Route>
                        <MasterLayout>
                            <Route exact path='/Home' component={Dashboard} />
                            <Route path='/counter' component={Counter} />
                            <Route path='/fetch-data' component={FetchData} />
                            <Route path='/MainClassification' component={MainClassification} />
                            <Route path='/SubClassifications' component={SubClassifications} />
                            <Route path='/Location' component={Location} />
                            <Route path='/LendingDetails' component={LendingDetails} />
                           
                        </MasterLayout>
                     </Route>
                   </Switch>
            </Router>
        </div>
    );
  }
}


//import React, { Component } from 'react'
//import { Route } from 'react-router';
//import { Layout } from './components/Layout/Layout';
//import { Home } from './components/Home';
//import { FetchData } from './components/FetchData';
//import { Counter } from './components/Counter';
//import { Menu } from './Menu';
//import { Navbar } from './Navbar';
//import { Footer } from './Footer';

//export default class App extends Component {
//    static displayName = App.name;

//    render() {
//        return (

//            <div>
//                <Menu />
//                <Navbar />
//                <Footer />
//            </div>

//        );
//    }
//}
