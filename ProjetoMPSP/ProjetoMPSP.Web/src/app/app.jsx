import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

import Header from './header.jsx';

import Buscador from './Buscador/buscador.jsx';

export default class App extends React.Component{
    render(){
        return(
            <Router>
                <Header />
                <div className="container">
                    <Switch>
                        <Route exact path="/" component={Buscador} />
                    </Switch>
                </div>
            </Router>
        );
    };
};