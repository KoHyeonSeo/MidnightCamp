import React from 'react';
import ReactDOM from 'react-dom/client';
import store from './store';
import App from './App';
import IndexStyle from './static/fonts/IndexStyle.module.css';
import { Provider } from 'react-redux';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <div className={ IndexStyle.index }>
    <span>
    <Provider store={ store }>
      <App/>
    </Provider>
    </span>
  </div>
);
