import { createActions, handleActions } from "redux-actions";

const initialState = [
    { 
        group_id: '',
        group_pwd: '',
        group_name: ''
    }
];

export const INIT_INFO = 'GROUP/INIT_INFO';
export const SHOW_INFO = 'GROUP/SHOW_INFO';
export const SET_INFO = 'GROUP/SET_INFO';

const actions = createActions({
    [INIT_INFO]: () => {},
    [SHOW_INFO]: () => {},
    [SET_INFO]: () => {}
});

export const groupReducer = handleActions(
    {
        [INIT_INFO]: (state, { payload }) => {

            state[0].group_id = '';
            state[0].group_pwd = '';
            state[0].group_name = '';

            return state;
        },
        [SHOW_INFO]: (state = initialState[0], { payload }) => {

            return payload;
        },
        [SET_INFO]: (state = initialState[0], { payload }) => {

            switch(payload.name) {
                case 'id':
                    state[0].group_id = payload.value; break;
                case 'pwd':
                    state[0].group_pwd = payload.value; break;
                case 'name':
                    state[0].group_name = payload.value; break;
            }

            return state;
        }
        
    },
    initialState
);

