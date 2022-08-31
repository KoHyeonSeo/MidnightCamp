import { combineReducers } from 'redux';
import { groupReducer } from './GroupModule';
import { modelReducer } from './ModelModule';

const rootReducer = combineReducers({
  
    groupReducer,
    modelReducer

});

export default rootReducer;