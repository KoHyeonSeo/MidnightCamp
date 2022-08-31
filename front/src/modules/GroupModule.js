import { createActions, handleActions } from "redux-actions";

const initialState = [
    { 
        group_id: '',
        group_pwd: '',
        group_name: ''
    }
];

export const INIT_GROUP_INFO = 'GROUP/INIT_GROUP_INFO';
export const SHOW_GROUP_INFO = 'GROUP/SHOW_GROUP_INFO';
export const SET_GROUP_INFO = 'GROUP/SET_GROUP_INFO';

const actions = createActions({
    [INIT_GROUP_INFO]: () => {},
    [SHOW_GROUP_INFO]: () => {},
    [SET_GROUP_INFO]: () => {}
});

export const groupReducer = handleActions(
    {
        [INIT_GROUP_INFO]: (state, { payload }) => {

            state[0].group_id = '';
            state[0].group_pwd = '';
            state[0].group_name = '';

            return state;
        },
        [SHOW_GROUP_INFO]: (state = initialState[0], { payload }) => {

            return payload;
        },
        [SET_GROUP_INFO]: (state = initialState[0], { payload }) => {

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

