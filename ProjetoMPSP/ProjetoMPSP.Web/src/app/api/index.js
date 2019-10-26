import axios from "axios";
import url from "api.config";

export default (dispatch, beginAction, successAction, failureAction) => {
  var instance = axios.create({
    baseURL: url
  });

  instance.interceptors.request.use(config => {
    dispatch({ type: beginAction });
    return config;
  });

  instance.interceptors.response.use(
    response => dispatch({ type: successAction, data: response.data }),
    error =>  dispatch({ type: failureAction, error: error }));

  return instance;
};
