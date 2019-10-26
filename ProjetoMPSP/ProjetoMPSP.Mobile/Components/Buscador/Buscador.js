import React, { Component } from 'react';
import { Text, View, TextInput, TouchableOpacity, CheckBox, AsyncStorage } from 'react-native';

import styles from "../../assets/styles/styles";

import api from '../../API/api'

import Cadesp from '../Cadesp/Cadesp';
import Censec from '../Censec/Censec';
import Arpensp from '../Arpensp/Arpensp';

export default class Buscador extends React.Component {
    render() {
        return (
            <View>
                <OpcoesBusca />
            </View>
        );
    }
}

export class CamposConsulta extends React.Component {
    static getDerivedStateFromProps(props, state) {
        if (props.ckboxCensec !== state.ckboxCensec ||
            props.ckboxCadesp !== state.ckboxCadesp ||
            props.ckboxArpensp !== state.ckboxArpensp ||
            props.ckboxArisp !== state.ckboxArisp ||
            props.ckboxCaged !== state.ckboxCaged) {
            return {
                ckboxCensec: props.ckboxCensec,
                ckboxCadesp: props.ckboxCadesp,
                ckboxArpensp: props.ckboxArpensp,
                ckboxArisp: props.ckboxArisp,
                ckboxCaged: props.ckboxCaged
            };
        }
        return null;
    };

    constructor(props) {
        super(props);
        this.state = {
            ckboxCensec: this.ckboxCensec,
            ckboxCadesp: this.ckboxCadesp,
            ckboxArpensp: this.ckboxArpensp,
            ckboxArisp: this.ckboxArisp,
            ckboxCaged: this.ckboxCaged
        }
    }

    state = {
        errorMessage: null
    }

    signIn = async () => {
        fetch('http://www.localhost:56840/', {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                login: 'yourValue',
                senha: 'yourOtherValue',
            }),
        });
    };

    render() {
        return (
            <View>
                {
                    /* Cadesp */
                    this.state.ckboxCadesp &&
                    <View style={styles.CampoLogin}>
                        <TextInput style={styles.textInput} placeholder="Login" />
                        <TextInput style={styles.textInput} placeholder="Senha" secureTextEntry={true} />
                        {this.state.errorMessage && <Text>{this.state.errorMessage}</Text>}
                        <TouchableOpacity onPress={() => this.signIn()} >
                            <Text style={styles.BotaoLogin}>Login</Text>
                        </TouchableOpacity>
                    </View>
                }
                {
                    this.state.ckboxCadesp &&
                    <View>
                        <TextInput style={styles.textInput} placeholder='CNPJ' underlineColorAndroid={'transparent'}></TextInput>
                    </View>
                }
                {
                    /* Censec */
                    this.state.ckboxCensec &&
                    <TextInput style={styles.textInput} placeholder='Documento' underlineColorAndroid={'transparent'}></TextInput>
                }
                {
                    /* Arpensp */
                    this.state.ckboxArpensp &&
                    <TextInput style={styles.textInput} placeholder='Número do Processo' underlineColorAndroid={'transparent'}></TextInput>
                }
                {
                    /* Arisp */
                    this.state.ckboxArisp &&
                    <TextInput style={styles.textInput} placeholder='CPF/CNPJ' underlineColorAndroid={'transparent'}></TextInput>
                }
                {
                    /* Caged CNPJ */
                    this.state.ckboxCaged &&
                    <View>
                        <TextInput style={styles.textInput} placeholder='CNPJ' underlineColorAndroid={'transparent'}></TextInput>
                        <TextInput style={styles.textInput} placeholder='Chave de Pesquisa' underlineColorAndroid={'transparent'}></TextInput>
                    </View>
                }
                <TouchableOpacity disabled={!this.state.ckboxCadesp && !this.state.ckboxCensec && !this.state.ckboxArpensp && !this.state.ckboxArisp && !this.state.ckboxCaged}>
                    <Text style={styles.btnExtrair}>Extrair</Text>
                </TouchableOpacity>
            </View>
        );
    }
}
export class OpcoesBusca extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            ckboxCensec: false,
            ckboxCadesp: false,
            ckboxArpensp: false,
            ckboxArisp: false,
            ckboxCaged: false
        }
    }

    render() {
        return (
            <View >
                <View style={styles.AlinhamentoCheckbox}>
                    <CheckBox style={styles.CheckboxOpcoes} value={this.state.ckboxArisp} onValueChange={() => this.setState({ ckboxArisp: !this.state.ckboxArisp })} /><Text style={styles.TextoOpcoes}>Arisp</Text>
                    <CheckBox style={styles.CheckboxOpcoes} value={this.state.ckboxArpensp} onValueChange={() => this.setState({ ckboxArpensp: !this.state.ckboxArpensp })} /><Text style={styles.TextoOpcoes}>Arpensp</Text>
                    <CheckBox style={styles.CheckboxOpcoes} value={this.state.ckboxCadesp} onValueChange={() => this.setState({ ckboxCadesp: !this.state.ckboxCadesp })} /><Text style={styles.TextoOpcoes}>Cadesp</Text>
                </View>
                <View style={styles.AlinhamentoCheckbox}>
                    <CheckBox style={styles.CheckboxOpcoes} value={this.state.ckboxCaged} onValueChange={() => this.setState({ ckboxCaged: !this.state.ckboxCaged })} /><Text style={styles.TextoOpcoes}>Caged</Text>
                    <CheckBox style={styles.CheckboxOpcoes} value={this.state.ckboxCensec} onValueChange={() => this.setState({ ckboxCensec: !this.state.ckboxCensec })} /><Text style={styles.TextoOpcoes}>Censec</Text>
                </View>

                <CamposConsulta {...this.state} />
            </View>
        )
    }
}