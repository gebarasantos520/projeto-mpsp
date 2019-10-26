import {
    ENVIAR_EXTRACAO_BEGIN,
    ENVIAR_EXTRACAO_SUCCESS,
    ENVIAR_EXTRACAO_FAILURE,

    DOWNLOAD_BEGIN,
    DOWNLOAD_SUCCESS,
    DOWNLOAD_FAILURE,

    ATIVAR_EXTRACAO

} from "./buscador.actions.js";

export const initialState = {
    loading: false
};

export default (state = initialState, action) => {
    switch (action.type) {
        case ENVIAR_EXTRACAO_BEGIN:
            return { ...state, loading: true };
        case ENVIAR_EXTRACAO_SUCCESS:
            return { ...state, id: action.response, loading: false }
        case ENVIAR_EXTRACAO_FAILURE:
            return { ...state, error: action.error, loading: false };

        case DOWNLOAD_BEGIN:
            return { ...state, loading: true, error: null };
        case DOWNLOAD_SUCCESS:
            return { ...state, loading: false };
        case DOWNLOAD_FAILURE:
            return { ...state, error: action.error, loading: false };

        case ATIVAR_EXTRACAO:
            return { ...state, extrair: action.extrair, loading: false };

        default:
            return state;
    }
};
