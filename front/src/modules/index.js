import { combineReducers } from 'redux';
import { groupReducer } from './GroupModule';
import { modelReducer } from './ModelModule';
import { loginReducer } from './LoginModule';

const rootReducer = combineReducers({
  
    groupReducer,
    modelReducer,
    loginReducer

});

export default rootReducer;