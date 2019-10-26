import createApi from "../api";

export const AUTH_CADESP_BEGIN = "AUTH_CADESP_BEGIN";
export const AUTH_CADESP_SUCCESS = "AUTH_CADESP_SUCCESS";
export const AUTH_CADESP_FAILURE = "AUTH_CADESP_FAILURE";

export const CADESP_BEGIN = "CADESP_BEGIN";
export const CADESP_SUCCESS = "CADESP_SUCCESS";
export const CADESP_FAILURE = "CADESP_FAILURE";

export const DOWNLOAD_BEGIN = "DOWNLOAD_BEGIN";
export const DOWNLOAD_SUCCESS = "DOWNLOAD_SUCCESS";
export const DOWNLOAD_FAILURE = "DOWNLOAD_FAILURE";

export const CADASTRAR_LOGIN = "CADASTRAR_LOGIN";

export const loginCadesp = (login, senha) => dispatch => {
    const api = createApi(
        dispatch,
        AUTH_CADESP_BEGIN,
        AUTH_CADESP_SUCCESS,
        AUTH_CADESP_FAILURE);

    return api.put(`api/cadesp/`, {
        login,
        senha
    });
};

export const buscarPessoa = cnpj => dispatch => {
    const api = createApi(
        dispatch,
        CADESP_BEGIN,
        CADESP_SUCCESS,
        CADESP_FAILURE);

    return api.post(`cadesp/`, {
        cnpj
    });
};

export const cadastrarLogin = (login, senha) =>{
    return{
        type: CADASTRAR_LOGIN,
        login: login,
        senha: senha
    };
};