import { combineReducers } from "redux";
import { connectRouter } from "connected-react-router";
import { reducer as formReducer } from "redux-form"

import buscador from '../Buscador/buscador.reducer.js';
import cadesp from '../Cadesp/cadesp.reducer.js';

export default history => combineReducers({
  router: connectRouter(history),
  form: formReducer,
  buscador,
  cadesp
});
