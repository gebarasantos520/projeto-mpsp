import React, { Component } from 'react';
import { StyleSheet, Text, View, TextInput, TouchableOpacity } from 'react-native';

export default class CensecLoginForm extends React.Component {
    render() {
        return (
            <View>
                <Text style={styles.header}>Login</Text>
                <TextInput style={styles.textInput} underlineColorAndroid={'transparent'}></TextInput>
                <Text style={styles.header} >Senha</Text>
                <TextInput secureTextEntry={true} style={styles.textInput} underlineColorAndroid={'transparent'}></TextInput>
                <TouchableOpacity>
                    <Text style={styles.btnBuscar}>Login</Text>
                </TouchableOpacity>
            </View>
        );
    }
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        backgroundColor: '#36458f',
        alignItems: 'center',
        justifyContent: 'center',
        paddingLeft: 60,
        paddingRight: 60
    },
    header: {
        fontSize: 24,
        color: '#fff',
        paddingBottom: 10,
        marginBottom: 40,
    },
    textInput: {
        alignSelf: 'stretch',
        height: 40,
        marginBottom: 30,
        color: '#fff',
        borderBottomColor: '#f8f8f8',
        borderBottomWidth: 1
    },
    btnBuscar: {
        alignSelf: 'stretch',
        alignItems: 'center',
        padding: 20,
        backgroundColor: '#59cbbd',
        marginTop: 30
      }
});