import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Navigate, NavLink, useNavigate } from 'react-router-dom';
import { LOGOUT } from '../../modules/LoginModule';
import HeaderStyle from '../../styles/Header.module.css'
import { logoutAlert } from '../items/alertDesign';

function Header() {

    const loginInfo = useSelector(state => state.loginReducer);
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const onClickHandler = () => {
        dispatch({ type: [LOGOUT]})
        logoutAlert();
        navigate(0)
    }

    useEffect(()=> {console.log(loginInfo[0].login_id)}, [loginInfo[0]])

    return (
        loginInfo[0].login_id?
        <div className={ HeaderStyle.header }>
            <h1 className={ HeaderStyle.h1 }>Header</h1>
            <h4 className={ HeaderStyle.h4 }>{loginInfo[0].login_id}님 환영합니다</h4>
            <button onClick={ onClickHandler }>로그아웃</button>
            <NavLink className={ HeaderStyle.signupButton } to="/hephaistos">
                <button>헤파이토스(2D) 조회</button>
            </NavLink>
        </div>
        :
        <div className={ HeaderStyle.header }>
            <h1 className={ HeaderStyle.h1 }>Header</h1>
            <NavLink className={ HeaderStyle.signinButton } to="/signin">
                <button>로그인</button>
            </NavLink>
            <NavLink className={ HeaderStyle.signupButton } to="/signup">
                <button>회원가입</button>
            </NavLink>
            <NavLink className={ HeaderStyle.signupButton } to="/hephaistos">
                <button>헤파이토스(2D) 조회</button>
            </NavLink>
        </div>
    );
}

export default Header;