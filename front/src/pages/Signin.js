import axios from "axios";
import { useEffect } from "react";
import { useCookies } from "react-cookie";
import { useSelector, useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { loginSuccessAlert } from "../components/items/alertDesign";
import { INIT_GROUP_INFO, SET_GROUP_INFO } from "../modules/GroupModule";
import { LOGIN } from "../modules/LoginModule";
import Button from '@mui/material/Button';
import SigninStyle from '../styles/Signin.module.css';

// 로그인 페이지

function Signin() {

    const groupInfo = useSelector(state => state.groupReducer);
    const loginInfo = useSelector(state => state.loginReducer);
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const [cookies, setCookie, removeCookie] = useCookies();

    const onChangeHandler = (e) => {
        dispatch({ type: [SET_GROUP_INFO], payload: e.target});
        console.log(groupInfo[0])
    }

    const onClickHandler = async (e) => {
        const signInMember = await axios({
            method: 'post',
            url: 'http://192.168.94.115:8888/auth/login',
            // 'http://192.168.1.51:8888/auth/login', // 서버 주소로 변경
            data: {
                id: groupInfo[0].group_id,
                password: groupInfo[0].group_pwd,
            }
        })

        //const currentTime = new Date();
        //currentTime.setDate(currentTime.getDate() + 3);
        //const accessTokenTime = currentTime;

        console.log('로그인 정보 :', signInMember);
        // if(cookies.acceessToken){
        //     removeCookie('accessToken');
        //     console.log('쿠키 삭제 완료');
        // }
        // await removeCookie('accessToken')
        setCookie('accessToken', signInMember.data.accessToken, {path: '/', expire: '3d', httpOnly: false});
        console.log(loginInfo[0])
        console.log(cookies.accessToken)
        if(cookies.accessToken) {
            dispatch({ type: [LOGIN], payload: groupInfo[0]});
            loginSuccessAlert(loginInfo[0].login_id)
            navigate('/');
        }

    }

    const onClickSignupHandler = () => {
        navigate('/signup');
    }

    useEffect(
        () => {
            dispatch({ type: [INIT_GROUP_INFO] });
        }, []
    );

    return (
        // 로그인 시 @@님 환영합니다 로그아웃 버튼 나오게
        // 로그아웃 시 로그인 회원가입 버튼 나오게
        <div className={ SigninStyle.body }>
            <div className={ SigninStyle.loginbox }>
                <h1 className={ SigninStyle.loginTitle }>로그인</h1>
                {/* <label htmlFor="id">아이디</label><br/> */}
                <input 
                        className={ SigninStyle.inputId }
                        type="text"
                        name="id"
                        placeholder="아이디를 입력하세요"
                        onChange={ onChangeHandler }
                />
                <br/>
                {/* <label htmlFor="pwd">비밀번호</label><br/> */}
                <input 
                        className={ SigninStyle.inputPassword }
                        type="password"
                        name="pwd"
                        placeholder="비밀번호를 입력하세요"
                        onChange={ onChangeHandler }        
                /><br/>

                <button 
                        type="submit"
                        onClick={ onClickHandler }
                        className={ SigninStyle.login }
                >
                    로그인
                </button>
                <button 
                        type="submit"
                        onClick={ onClickSignupHandler }
                        className={ SigninStyle.login }
                >
                    회원가입
                </button>
            </div>
        </div>
    );
}

export default Signin;