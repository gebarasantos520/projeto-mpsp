import React from 'react';
import { Form, Field, reduxForm, formValueSelector } from "redux-form";
import { connect } from "react-redux";
import { Route } from "react-router-dom";

import Cadesp from '../Cadesp/cadesp.jsx';
import Censec from '../Censec/censec.jsx';
import Arpensp from '../Arpensp/arpensp.jsx';

import * as actions from './buscador.actions.js';

class Autenticado extends React.Component {
    render() {
        return (

            <div className="row">
                <div className="col-12">
                    <div className="alert alert-success mb-0 text-center" role="alert">
                        <strong>Autenticado com sucesso.</strong>
                    </div>
                </div>
            </div>
        );
    }
};

class CamposConsulta extends React.Component {
    form = reduxForm({ form: "pesquisa" })(props => {
        const { arisp, arpensp, cadesp, caged, censec, detran, infocrim, siel, sivec, loading, extrairDados } = props;
        return (
            <Form onSubmit={extrairDados}>
                {
                    (arisp) &&
                    <div>
                        <h5 className="p-2 alert-dark">ARISP</h5>
                        <div className="form-group">
                            <label>Documento</label>
                            <Field name="documentoarisp" disabled={loading} type="text" component="input" className="form-control" required />
                        </div>
                    </div>
                }
                {
                    (arpensp) &&
                    <div>
                        <h5 className="p-2 alert-dark">ARPENSP</h5>
                        <div className="form-group">
                            <label>Numero Processo</label>
                            <Field name="numeroProcesso" disabled={loading} type="text" component="input" className="form-control" required />
                        </div>
                    </div>
                }
                {
                    (cadesp) &&
                    <div>
                        <h5 className="p-2 alert-dark">CADESP</h5>
                        <div className="form-group">
                            <label>CNPJ</label>
                            <Field name="cnpj" disabled={loading} type="text" component="input" className="form-control" required />
                        </div>
                    </div>
                }
                {
                    (caged) &&
                    <div>
                        <h5 className="p-2 alert-dark">CAGED</h5>
                        <div className="form-group">
                            <label>CNPJ</label>
                            <Field name="cagedcnpj" disabled={loading} type="text" component="input" className="form-control" required />
                            <label>Chave de Pesquisa</label>
                            <Field name="chavePesquisa" disabled={loading} type="text" component="input" className="form-control" required />
                        </div>
                    </div>
                }
                {
                    (censec) &&
                    <div>
                        <h5 className="p-2 alert-dark">CENSEC</h5>
                        <div className="form-group">
                            <label>Documento</label>
                            <Field name="documentocensec" disabled={loading} type="text" component="input" className="form-control" required />
                        </div>
                    </div>
                }
                {
                    (detran) &&
                    <div>
                        <h5 className="p-2 alert-dark">DETRAN</h5>
                        <div className="form-group">
                            <label>Tipo</label>
                            <Field name="option" component="select" className="form-control">
                                <option value='1'>Pessoa</option>
                                <option value='2'>Veiculo</option>
                            </Field>
                        </div>
                        <div className="form-group">
                            <label>Nome</label>
                            <Field name="nomedetran" disabled={loading} type="text" component="input" className="form-control" required />
                        </div>
                        <div className="form-group">
                            <label>CPF</label>
                            <Field name="cpfdetran" disabled={loading} type="text" component="input" className="form-control" required />
                        </div>
                        <div className="form-group">
                            <label>Placa</label>
                            <Field name="placadetran" disabled={loading} type="text" component="input" className="form-control" required />
                        </div>
                    </div>
                }
                {
                    (siel) &&
                    <div>
                        <h5 className="p-2 alert-dark">SIEL</h5>
                        <div className="form-group">
                            <label>Nome</label>
                            <Field name="nomesiel" disabled={loading} type="text" component="input" className="form-control" required />
                        </div>
                        <div className="form-group">
                            <label>Numero Processo</label>
                            <Field name="numeroprocessosiel" disabled={loading} type="text" component="input" className="form-control" required />
                        </div>
                    </div>
                }
                {
                    (sivec) &&
                    <div>
                        <h5 className="p-2 alert-dark">SIVEC</h5>
                        <div className="form-group">
                            <label>Documento</label>
                            <Field name="documento" disabled={loading} type="text" component="input" className="form-control" required />
                        </div>
                    </div>
                }
                <button type="submit" disabled={loading} className="btn btn-dark shadow">
                    <i className="fas fa-sign-in-alt"></i> <strong className="text-uppercase">Extrair</strong>
                </button>
            </Form>
        );
    });
    render() {
        const { arisp, arpensp, cadesp, caged, censec, detran, infocrim, siel, sivec, loading, extrairDados } = this.props;
        if (arisp || arpensp || cadesp || caged || censec || detran || infocrim || siel || sivec) {
            return (
                <div className="row">
                    <div className="col-12">
                        {
                            React.createElement(this.form, {
                                arisp,
                                arpensp,
                                cadesp,
                                caged,
                                censec,
                                detran,
                                infocrim,
                                siel,
                                sivec,
                                loading,
                                extrairDados
                            })
                        }
                    </div>
                </div>
            );
        }
        return null;
    };
};

class CardSistema extends React.Component {
    render() {
        const { arisp, arpensp, cadesp, caged, censec, detran, infocrim, siel, sivec } = this.props;
        if (arpensp || cadesp || caged || censec || detran || infocrim || siel || sivec) {
            return (
                <div className="row">
                    {
                        arpensp &&
                        <div className="col-12 col-md-4 mt-2">
                            <div className="card">
                                <div className="card-body">
                                    <h5 className="card-title text-center">Arpensp</h5>
                                    <hr />
                                    <Route component={Autenticado} />
                                </div>
                            </div>
                        </div>
                    }
                    {
                        cadesp &&
                        <div className="col-12 col-md-4 mt-2">
                            <div className="card">
                                <Route component={Cadesp} />
                            </div>
                        </div>
                    }
                    {
                        caged &&
                        <div className="col-12 col-md-4 mt-2">
                            <div className="card">
                                <div className="card-body">
                                    <h5 className="card-title text-center">Caged</h5>
                                    <hr />
                                    <Route component={Autenticado} />
                                </div>
                            </div>
                        </div>
                    }
                    {
                        censec &&
                        <div className="col-12 col-md-4 mt-2">
                            <div className="card">
                                <div className="card-body">
                                    <h5 className="card-title text-center">Censec</h5>
                                    <hr />
                                    <Route component={Autenticado} />
                                </div>
                            </div>
                        </div>
                    }
                    {
                        detran &&
                        <div className="col-12 col-md-4 mt-2">
                            <div className="card">
                                <div className="card-body">
                                    <h5 className="card-title text-center">Detran</h5>
                                    <hr />
                                    <Route component={Autenticado} />
                                </div>
                            </div>
                        </div>
                    }
                    {
                        infocrim &&
                        <div className="col-12 col-md-4 mt-2">
                            <div className="card">
                                <div className="card-body">
                                    <h5 className="card-title text-center">Infocrim</h5>
                                    <hr />
                                    <Route component={Autenticado} />
                                </div>
                            </div>
                        </div>
                    }
                    {
                        siel &&
                        <div className="col-12 col-md-4 mt-2">
                            <div className="card">
                                <div className="card-body">
                                    <h5 className="card-title text-center">Siel</h5>
                                    <hr />
                                    <Route component={Autenticado} />
                                </div>
                            </div>
                        </div>
                    }
                    {
                        sivec &&
                        <div className="col-12 col-md-4 mt-2">
                            <div className="card">
                                <div className="card-body">
                                    <h5 className="card-title text-center">Sivec</h5>
                                    <hr />
                                    <Route component={Autenticado} />
                                </div>
                            </div>
                        </div>
                    }
                </div>
            );
        }
        return (
            <div className="row">
                <div className="col-12">
                    <div className="alert alert-info mb-0 text-center" role="alert">
                        <strong>Ainda não foi selecionado nenhum sistema.</strong>
                    </div>
                </div>
            </div>
        );
    }
};

class Buscador extends React.Component {
    extrairDados = e => {
        const { dispatch, sistemas, formPesquisa, Buscador } = this.props;
        const { Cadesp } = sistemas;
        e.preventDefault();
        if (Cadesp.ativo) {
            if (Cadesp.ativo) {
                dispatch(actions.enviarExtracao(formPesquisa.values["cnpj"], Cadesp.auth.nome, Cadesp.auth.senha, "Cadesp")).then(action=>{
                    if(action.type === actions.ENVIAR_EXTRACAO_SUCCESS){
                        dispatch(actions.ativarExtrair(action.data));
                    }
                });
            }
        }
    };
    extrairRelatorio = e => {
        e.preventDefault();
        const { dispatch, Buscador } = this.props;
        dispatch(actions.downloadArquivo(Buscador.extrair));
    };
    form = reduxForm({ form: "sistemas" })(props => {
        return (
            <div>
                <div className="form-check form-check-inline">
                    <Field
                        type="checkbox"
                        name="arisp"
                        id="arisp"
                        label="Arisp"
                        className="form-check-input"
                        component="input" />
                    <label className="form-check-label text-danger" htmlFor="arisp"><strong>ARISP</strong></label>
                </div>
                <div className="form-check form-check-inline">
                    <Field
                        type="checkbox"
                        name="arpensp"
                        id="arpensp"
                        label="Arpensp"
                        className="form-check-input"
                        component="input" />
                    <label className="form-check-label text-danger" htmlFor="arpensp"><strong>ARPENSP</strong></label>
                </div>
                <div className="form-check form-check-inline">
                    <Field
                        type="checkbox"
                        name="cadesp"
                        id="cadesp"
                        label="Cadesp"
                        className="form-check-input"
                        component="input" />
                    <label className="form-check-label text-success" htmlFor="cadesp"><strong>CADESP</strong></label>
                </div>
                <div className="form-check form-check-inline">
                    <Field
                        type="checkbox"
                        name="caged"
                        id="caged"
                        label="Caged"
                        className="form-check-input"
                        component="input" />
                    <label className="form-check-label text-danger" htmlFor="caged"><strong>CAGED</strong></label>
                </div>
                <div className="form-check form-check-inline">
                    <Field
                        type="checkbox"
                        name="censec"
                        id="censec"
                        label="Censec"
                        className="form-check-input"
                        component="input" />
                    <label className="form-check-label text-danger" htmlFor="censec"><strong>CENSEC</strong></label>
                </div>
                <div className="form-check form-check-inline">
                    <Field
                        type="checkbox"
                        name="detran"
                        id="detran"
                        label="Detran"
                        className="form-check-input"
                        component="input" />
                    <label className="form-check-label text-danger" htmlFor="detran"><strong>DETRAN</strong></label>
                </div>
                <div className="form-check form-check-inline">
                    <Field
                        type="checkbox"
                        name="infocrim"
                        id="infocrim"
                        label="Infocrim"
                        className="form-check-input"
                        component="input" />
                    <label className="form-check-label text-danger" htmlFor="infocrim"><strong>INFOCRIM</strong></label>
                </div>
                <div className="form-check form-check-inline">
                    <Field
                        type="checkbox"
                        name="siel"
                        id="siel"
                        label="Siel"
                        className="form-check-input"
                        component="input" />
                    <label className="form-check-label text-danger" htmlFor="siel"><strong>SIEL</strong></label>
                </div>
                <div className="form-check form-check-inline">
                    <Field
                        type="checkbox"
                        name="sivec"
                        id="sivec"
                        label="Sivec"
                        className="form-check-input"
                        component="input" />
                    <label className="form-check-label text-danger" htmlFor="sivec"><strong>SIVEC</strong></label>
                </div>
            </div>
        );
    });
    render() {
        if (this.props) {
            const { Buscador } = this.props;
            return (
                <div className="row justify-content-center">
                    <div className="col-12">
                        <div className="card mt-4 mb-4 shadow border-radius">
                            <div className="card-body p-3">
                                <h3 className="mb-0 text-center">Buscador Geral do MPSP</h3>
                            </div>
                        </div>
                        <div className="card mt-4 shadow border-radius mb-4">
                            <div className="card-body p-3">
                                <div className="row">
                                    <div className="col-12">
                                        <h5>Selecione o sistemas e aguarde:</h5>
                                        {
                                            React.createElement(this.form)
                                        }
                                    </div>
                                </div>
                                <hr />
                                <CardSistema {...this.props} />
                                <hr />
                                <CamposConsulta {...this.props} loading={Buscador.loading} extrairDados={this.extrairDados} />
                                {
                                    Buscador.extrair &&
                                    <button onClick={this.extrairRelatorio} className="btn btn-dark shadow float-right">
                                        <i className="fas fa-sign-in-alt"></i> <strong className="text-uppercase">Baixar relatorio</strong>
                                    </button>
                                }
                            </div>
                        </div>
                    </div>
                </div>
            );
            return null;
        }
    };
};

const selector = formValueSelector('sistemas');

export default connect(
    (state) => ({
        Buscador: state.buscador,
        formPesquisa: state.form.pesquisa,
        arisp: selector(state, 'arisp'),
        arpensp: selector(state, 'arpensp'),
        cadesp: selector(state, 'cadesp'),
        caged: selector(state, 'caged'),
        censec: selector(state, 'censec'),
        detran: selector(state, 'detran'),
        infocrim: selector(state, 'infocrim'),
        siel: selector(state, 'siel'),
        sivec: selector(state, 'sivec'),
        sistemas: {
            Arisp: { ativo: selector(state, 'arisp') },
            Arpensp: { ativo: selector(state, 'arpensp') },
            Cadesp: {
                ativo: selector(state, 'cadesp'),
                auth: state.cadesp.autenticado ? { nome: state.cadesp.login, senha: state.cadesp.senha } : null
            },
            Caged: { ativo: selector(state, 'caged') },
            Censec: { ativo: selector(state, 'censec') },
            Detran: { ativo: selector(state, 'detran') },
            Infocrim: { ativo: selector(state, 'infocrim') },
            Siel: { ativo: selector(state, 'siel') },
            Sivec: { ativo: selector(state, 'sivec') },
        }
    })
)(Buscador);