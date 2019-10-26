import { hot } from "react-hot-loader/root"
import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { ConnectedRouter } from "connected-react-router";

import configureStore, { history, initialState } from "./app/store";
import App from "./app/app.jsx";

import "./css/index.css";

const store = configureStore(initialState);
const HotApp = hot(App);

ReactDOM.render(
    <Provider store={store}>
        <ConnectedRouter history={history}>
            <HotApp />
        </ConnectedRouter>
    </Provider>,
    document.getElementById("app")
);