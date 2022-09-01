import { createActions, handleActions } from "redux-actions";

const initialState = [
    { 
        model_code: '',
        model_name: '',
        search_key: '',
        search_type: '',
        search_result: []
        // model 정보 추가
    }
];

export const INIT_MODEL_INFO = 'GROUP/INIT_MODEL_INFO';
export const SHOW_MODEL_INFO = 'GROUP/SHOW_MODEL_INFO';
export const SET_MODEL_INFO = 'GROUP/SET_MODEL_INFO';
export const SET_SEARCH_KEY = 'GROUP/SET_SEARCH_KEY';
export const SET_SEARCH_TYPE = 'GROUP/SET_SEARCH_TYPE';
export const SET_SEARCH_RESULT = 'GROUP/SET_SEARCH_RESULT';


const actions = createActions({
    [INIT_MODEL_INFO]: () => {},
    [SHOW_MODEL_INFO]: () => {},
    [SET_MODEL_INFO]: () => {},
    [SET_SEARCH_KEY]: () => {},
    [SET_SEARCH_TYPE]: () => {},
    [SET_SEARCH_RESULT]: () => {}

});

export const modelReducer = handleActions(
    {
        [INIT_MODEL_INFO]: (state, { payload }) => {

            state[0].model_code = '';
            state[0].model_name = '';
            state[0].search_key = '';
            state[0].search_type = '';
            state[0].search_result = [];

            return state;
        },
        [SHOW_MODEL_INFO]: (state, { payload }) => {

            return payload;
        },
        [SET_MODEL_INFO]: (state, { payload }) => {

            switch(payload.value) {
                case 'modelName':
                    state[0].model_name = payload.value; break;
            }

            return state;
        },
        [SET_SEARCH_KEY]: (state, { payload }) => {

            state[0].search_key = payload.value;

            return state;
        },
        [SET_SEARCH_TYPE]: (state, { payload }) => {

            state[0].search_type = payload.options[payload.selectedIndex].text;

            return state;
        },
        [SET_SEARCH_RESULT]: (state, { payload }) => {

            state[0].search_result = payload.data.results;
            
            return state;
        }

        
    },
    initialState
);

