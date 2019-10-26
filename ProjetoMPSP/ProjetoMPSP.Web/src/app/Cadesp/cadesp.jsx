import React from 'react';
import { Form, Field, reduxForm } from "redux-form";
import { createTextMask } from "redux-form-input-masks";
import { connect } from "react-redux";

import * as actions from './cadesp.action.js';

class LoginCadesp extends React.Component {
    form = reduxForm({ form: "logincadesp" })(props => {
        const { logarCadesp, loading } = props;
        return (
            <Form onSubmit={logarCadesp}>
                <div className="form-group">
                    <label>Login</label>
                    <Field name="login" disabled={loading} type="text" component="input" className="form-control" required />
                </div>
                <div className="form-group">
                    <label>Senha</label>
                    <Field name="senha" disabled={loading} type="password" component="input" className="form-control" required />
                </div>
                <button type="submit" disabled={loading} className="btn btn-dark shadow">
                    <i className="fas fa-sign-in-alt"></i> <strong className="text-uppercase">Logar</strong>
                </button>
            </Form>
        );
    });
    render() {
        const { logarCadesp, loading } = this.props;
        return (
            <div className="row">
                <div className="col-12">
                    {
                        React.createElement(this.form, {
                            logarCadesp: logarCadesp,
                            loading: loading
                        })
                    }
                </div>
            </div>
        );
    };
};

class Cadesp extends React.Component {
    logarCadesp = e => {
        const { dispatch, formLogin } = this.props;
        e.preventDefault();

        dispatch(actions.loginCadesp(formLogin.values["login"], formLogin.values["senha"])).then(action => {
            if (actions.AUTH_CADESP_SUCCESS === action.type) 
            { 
                dispatch(actions.cadastrarLogin(formLogin.values["login"], formLogin.values["senha"])) 
            }
        });
    };
    render() {
        const { cadesp } = this.props;
        if (cadesp) {
            const { autenticado, loading } = cadesp;
            return (
                <div className="card-body">
                    <h5 className="card-title text-center">Cadesp <sub><span className="badge badge-info">{autenticado}</span></sub></h5>
                    <hr />
                    {
                        autenticado ?
                            <div className="row">
                                <div className="col-12">
                                    <div className="alert alert-success mb-0 text-center" role="alert">
                                        <strong>Autenticado com sucesso.</strong>
                                    </div>
                                </div>
                            </div> :
                            <LoginCadesp logarCadesp={this.logarCadesp} loading={loading} />
                    }
                </div>
            );
        }
        return null;
    };
};

export default connect(
    (state) => ({
        cadesp: state.cadesp,
        formLogin: state.form.logincadesp
    })
)(Cadesp);