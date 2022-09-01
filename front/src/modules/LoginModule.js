import { createActions, handleActions } from "redux-actions";

const initialState = [
    { 
        login_id: ''
    }
];

export const LOGIN = 'AUTH/LOGIN';
export const LOGOUT = 'AUTH/LOGOUT';


const actions = createActions({
    [LOGIN]: () => {},
    [LOGOUT]: () => {}
});

export const loginReducer = handleActions(
    {
        [LOGIN]: (state, { payload }) => {

            state[0].login_id = payload.group_id;

            return state;
        },
        [LOGOUT]: (state = initialState[0], { payload }) => {

            state[0].login_id = '';

            return state;
        }
    },
    initialState
);

