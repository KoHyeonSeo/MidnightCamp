import axios from "axios";
import { useCookies } from "react-cookie";
import { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { INIT_GROUP_INFO, SET_GROUP_INFO } from "../modules/GroupModule";
import { LOGIN } from "../modules/LoginModule";
import { useNavigate } from "react-router-dom";
import { loginFailAlert, loginSuccessAlert } from "../components/items/alertDesign";
function Signin() {

    const groupInfo = useSelector(state => state.groupReducer);
    const loginInfo = useSelector(state => state.loginReducer);
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const [cookies, setCookie, removeCookie] = useCookies(['']);

    const onChangeHandler = (e) => {
        dispatch({ type: [SET_GROUP_INFO], payload: e.target});
        console.log(groupInfo[0])
    }

    const onClickHandler = async (e) => {
        const signInMember = await axios({
            method: 'post',
            url: //'http://localhost:8888/auth/login',
            'http://192.168.1.51:8888/auth/login', // 서버 주소로 변경
            data: {
                id: groupInfo[0].group_id,
                password: groupInfo[0].group_pwd,
            }
        })

        console.log('로그인 정보 :', signInMember)

        // httpOnly 설정
        setCookie('accessToken', signInMember.data.accessToken, {path: '/', expiresIn: '3d', httpOnly: false});
        //removeCookie('accessToken')
        console.log('cookie', cookies.accessToken)
        console.log(signInMember)
        if(cookies.accessToken) {
            dispatch({ type: [LOGIN], payload: groupInfo[0]})
            loginSuccessAlert(groupInfo[0].group_id);
            navigate("/");
        } else {
            loginFailAlert();
        }
    }

    useEffect(
        () => {
            dispatch({ type: [INIT_GROUP_INFO] });
        }, []
    );

    return (
        // 로그인 시 @@님 환영합니다 로그아웃 버튼 나오게
        // 로그아웃 시 로그인 회원가입 버튼 나오게
        <div>
            <label htmlFor="id">아이디</label><br/>
            <input 
                    type="text"
                    name="id"
                    placeholder="아이디를 입력하세요"
                    onChange={ onChangeHandler }
            />
            <br/>
            <label htmlFor="pwd">비밀번호</label><br/>
            <input 
                    type="password"
                    name="pwd"
                    placeholder="비밀번호를 입력하세요"
                    onChange={ onChangeHandler }        
            /><br/>

            <button
                    type="submit"
                    onClick={ onClickHandler }
            >
                로그인
            </button>
        </div>
    );
}

export default Signin;