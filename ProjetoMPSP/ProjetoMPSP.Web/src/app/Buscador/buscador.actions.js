import createApi from "../api";

export const ENVIAR_EXTRACAO_BEGIN = "ENVIAR_EXTRACAO_BEGIN";
export const ENVIAR_EXTRACAO_SUCCESS = "ENVIAR_EXTRACAO_SUCCESS";
export const ENVIAR_EXTRACAO_FAILURE = "ENVIAR_EXTRACAO_FAILURE";

export const DOWNLOAD_BEGIN = "DOWNLOAD_BEGIN";
export const DOWNLOAD_SUCCESS = "DOWNLOAD_SUCCESS";
export const DOWNLOAD_FAILURE = "DOWNLOAD_FAILURE";

export const ATIVAR_EXTRACAO = "ATIVAR_EXTRACAO";

export const enviarExtracao = (dado, login, senha, sistema) => dispatch => {
  const api = createApi(
    dispatch,
    ENVIAR_EXTRACAO_BEGIN,
    ENVIAR_EXTRACAO_SUCCESS,
    ENVIAR_EXTRACAO_FAILURE);

  return api.post(`api/${sistema}/`, {
    cnpj: dado,
    login,
    senha
  });
}

export const downloadArquivo = (id) => dispatch => {
  const api = createApi(
    dispatch,
    DOWNLOAD_BEGIN,
    DOWNLOAD_SUCCESS,
    DOWNLOAD_FAILURE);

  return api.get(`relatorio/${id}`, {
    responseType: 'blob'
  }).then(response => {
    if (response.type === DOWNLOAD_SUCCESS) {
      const a = document.createElement("a");
      const url = window.URL.createObjectURL(new Blob([response.data]));
      a.style.display = "none";
      a.href = url;
      a.download = "Relatorio.pdf";
      a.target = "_blank";
      document.body.appendChild(a);
      a.click();
      window.URL.revokeObjectURL(url);
      a.remove();
    }
  });
};

export const ativarExtrair = (id) => {
  return{
    type: ATIVAR_EXTRACAO,
    extrair: id
  }
};
