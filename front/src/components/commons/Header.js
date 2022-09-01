import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { NavLink, useNavigate } from 'react-router-dom';
import { LOGOUT } from '../../modules/LoginModule';
import HeaderStyle from '../../styles/Header.module.css'
import { logoutAlert } from '../items/alertDesign';
import styled from 'styled-components';

function Header() {

    // 로그인 이후 => 환영합니다 버튼 온 클릭 활성화 해야함

    const loginInfo = useSelector(state => state.loginReducer);
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const onClickLogoutHandler = () => {
        dispatch({ type: [LOGOUT]});
        logoutAlert();
        navigate('/');
    }

    const onClickLogo = () => {
        navigate('/');
    }

    const onCLickWelCome = () => {
        
    }


    useEffect(
        () => {

        }, [loginInfo[0].login_id]
    )

    return (
        !loginInfo[0].login_id?
        <div className={ HeaderStyle.header }>
            <img className={ HeaderStyle.img } onClick={ onClickLogo } src={require("../../static/images/logo.png")}/>
            <NavLink className={ HeaderStyle.signUp } to={"/signup"}>
                {/* <img className={ HeaderStyle.signUp } src={require('../../static/images/join_d.png')} /> */}
                간단 회원가입
            </NavLink>
            <NavLink className={ HeaderStyle.signIn } to={"/signin"}>
                {/* <img className={ HeaderStyle.signIn } src={require('../../static/images/login_d.png') }/> */}
                로그인하기
            </NavLink>
            {/* <NavLink to="/hephaistos">
                <button className={ HeaderStyle.search }>헤파이토스(2D) 조회</button>
            </NavLink> */}
            {/* <NavLink to="/test">
                <button className={ HeaderStyle.search }>테스트</button>
            </NavLink> */}
        </div>
        :
        <div className={ HeaderStyle.header }>
            <div className={ HeaderStyle.wrapper }>
            <img className={ HeaderStyle.img } onClick={ onClickLogo } src={require("../../static/images/logo.png")}/>
            <button className={ HeaderStyle.button } onClick={ onCLickWelCome }>
                {/* <img className={ HeaderStyle.button } src={require("../../static/images/환영합니다.png")}/> */}
            </button>    
                {/* <h4 className={ HeaderStyle.h4 }>{ loginInfo[0].login_id }님 환영합니다</h4> */}
                <img onClick={ onClickLogoutHandler }/>
                <button  className={ HeaderStyle.signOut } onClick={ onClickLogoutHandler }>
                {/* <img className={ HeaderStyle.signIn } src={require('../../static/images/login_d.png') }/> */}
                로그아웃 하기
                </button>
                {/* <NavLink className={ HeaderStyle.signupButton } to="/hephaistos">
                    <button>헤파이토스(2D) 조회</button>
                </NavLink> */}
            </div>
        </div>
    );
}

export default Header;