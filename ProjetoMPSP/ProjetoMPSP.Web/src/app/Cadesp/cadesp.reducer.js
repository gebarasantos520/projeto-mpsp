import {
    AUTH_CADESP_BEGIN,
    AUTH_CADESP_SUCCESS,
    AUTH_CADESP_FAILURE,

    CADESP_BEGIN,
    CADESP_SUCCESS,
    CADESP_FAILURE,

    DOWNLOAD_BEGIN,
    DOWNLOAD_SUCCESS,
    DOWNLOAD_FAILURE,

    CADASTRAR_LOGIN

} from "./cadesp.action.js";

export const initialState = {
    autenticado: null,
    login: null,
    senha: null,
    loading: false
};

export default (state = initialState, action) => {
    switch (action.type) {
        case AUTH_CADESP_BEGIN:
            return { ...state, loading: true };
        case AUTH_CADESP_SUCCESS:
            return { ...state, autenticado: true, loading: false }
        case AUTH_CADESP_FAILURE:
            return { ...state, error: action.error, loading: false };
        /*ADICIONAR ERROR NO FAILURE*/
        case CADESP_BEGIN:
            return { ...state, loading: true };
        case CADESP_SUCCESS:
            return { ...state, pessoa: "a", loading: false }
        case CADESP_FAILURE:
            return { ...state, pessoa: "a", loading: false };
        /*ADICIONAR ERROR NO FAILURE*/
        case DOWNLOAD_BEGIN:
            return { ...state, loading: true };
        case DOWNLOAD_SUCCESS:
            return { ...state, loading: false }
        case DOWNLOAD_FAILURE:
            return { ...state, error: action.error, loading: false };

        case CADASTRAR_LOGIN:
            return { ...state, login: action.login, senha: action.senha, loading: false };

        default:
            return state;
    }
};
