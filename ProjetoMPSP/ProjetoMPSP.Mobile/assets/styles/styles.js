import { StyleSheet } from 'react-native';

export default styles = StyleSheet.create({
    container: {
        backgroundColor: '#1f1f1f',
        height: 100000
        // paddingLeft: 60,
        // paddingRight: 60
    },
    textInput: {
        alignSelf: 'stretch',
        height: 40,
        marginBottom: 30,
        color: 'white',
        borderBottomColor: '#f8f8f8',
        borderBottomWidth: 1
    },
    btnExtrair: {
        alignSelf: 'stretch',
        alignItems: 'center',
        padding: 20,
        backgroundColor: '#b6b6b6',
        marginTop: 30,
        justifyContent: 'center',
    },
    TextoOpcoes: {
        color: 'white',
        paddingLeft: 5
    },
    CheckboxOpcoes: {
        flexDirection: 'row',
        padding: 5,
        alignItems: 'center'
    },
    header: {
        backgroundColor: 'white',
        marginTop: 22,
        paddingBottom: 10,
        marginBottom: 30,
        marginLeft: 10,
        marginRight: 250
    },
    LogoFiap: {
        maxWidth: 100,
        height: 'auto',
        width: 110,
        height: 25
    },
    AlinhamentoCheckbox: {
        flex: 1,
        flexDirection: 'row',
        padding: 15,
        alignItems: 'center',
        flexDirection: 'row'
    },
    CampoLogin: {
        backgroundColor: '#363636',
        marginTop: 20,
    },
    BotaoLogin: {
        padding: 20,
        backgroundColor: '#b6b6b6',
        justifyContent: 'center',
    }
});
