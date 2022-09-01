import { createActions, handleActions } from "redux-actions";

const initialState = [
    { 
        login_id: '',
        login_name: ''
    }
];

export const LOGIN = 'AUTH/LOGIN';
export const LOGOUT = 'AUTH/LOOUT';

const actions = createActions({
    [LOGIN]: () => {},
    [LOGOUT]: () => {}
});

export const loginReducer = handleActions(
    {
        [LOGOUT]: (state, { payload }) => {

            state[0].login_id = '';
            state[0].login_pwd = '';

            return state;
        },
        [LOGIN]: (state = initialState[0], { payload }) => {

            state[0].login_id = payload.group_id;
            state[0].login_name = payload.group_name;

            return state;
        }
        
    },
    initialState
);

