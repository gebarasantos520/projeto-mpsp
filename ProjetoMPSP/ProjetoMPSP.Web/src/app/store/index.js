import { createBrowserHistory } from "history";
import { createStore, applyMiddleware, compose } from "redux";
import { routerMiddleware } from "connected-react-router";

import thunk from "redux-thunk";
import createReducer from "../reducer";
import buscadorReducer from '../Buscador/buscador.reducer.js';
import cadespReducer from '../Cadesp/cadesp.reducer.js';

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

export const initialState = {
  buscador: buscadorReducer.initialState,
  cadesp: cadespReducer.initialState
};

export const history = createBrowserHistory();

export default preloadedState => createStore(
  createReducer(history),
  preloadedState,
  composeEnhancers(applyMiddleware(
    routerMiddleware(history),
    thunk))
);
