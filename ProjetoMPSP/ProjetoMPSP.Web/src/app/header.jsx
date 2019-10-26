import React from "react";
import { Link } from "react-router-dom";

import logo from '../img/logo-fiap.png';

class Header extends React.Component {
    render() {
        return (
            <header>
                <nav className="navbar navbar-expand-lg navbar-dark bg-fiap">
                    <Link to="/" className="navbar-brand">
                        <h1 className="text-uppercase h3 mb-0"><img src={logo} width="120" height="120" className="img-fluid" alt="Logotipo Fiap" /> <strong><sub>Projeto MPSP</sub></strong></h1>
                    </Link>
                    <button className="navbar-toggler" type="button" aria-controls="menu">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse">
                        <ul className="navbar-nav ml-auto">
                            <li className="nav-item">
                                <Link to="/login" className="nav-link h5 mb-0 text-uppercase text-fiap">
                                    <strong><i className="fas fa-sign-in-alt"></i> Login </strong>
                                </Link>
                            </li>
                        </ul>
                    </div>
                </nav>
            </header>
        );
    };
};

export default Header