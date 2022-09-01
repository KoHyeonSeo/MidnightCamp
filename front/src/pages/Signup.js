import axios from "axios";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { signupSuccessAlert } from "../components/items/alertDesign";
import { INIT_GROUP_INFO, SET_GROUP_INFO } from "../modules/GroupModule";
import { createTheme, ThemeProvider } from '@mui/material/styles';
import SignupStyle from "../styles/Signup.module.css";

// 회원가입 페이지

function Signup() {

    const theme = createTheme();

    const groupInfo = useSelector(state => state.groupReducer);
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const onChangeHandler = (e) => {
        dispatch({ type: [SET_GROUP_INFO], payload: e.target})
        console.log(groupInfo[0])
    }

    const onClickHandler = async (e) => {
        const signUpMember = await axios({
            method: 'post',
            url: 'http://192.168.1.51:8888/auth/regist', // 서버 주소로 변경
            data: {
                id: groupInfo[0].group_id,
                password: groupInfo[0].group_pwd,
                name: groupInfo[0].group_name
            }
        })

        console.log('회원가입 정보 :', signUpMember)
        if(signUpMember.data.results.affectedRows===1){
            signupSuccessAlert();
            navigate('/');
        }
    }

    useEffect(
        () => {
            dispatch({ type: [INIT_GROUP_INFO] });
        }, []
    );

    return (
        <div className={ SignupStyle.body }>
            <div className={ SignupStyle.signbox }>
                <h1 className={ SignupStyle.signTitle }>회원가입</h1>
                {/* <label htmlFor="id">아이디</label><br/> */}
                <input 
                        className={ SignupStyle.signId }
                        type="text"
                        name="id"
                        placeholder="아이디를 입력하세요"
                        onChange={ onChangeHandler }
                />
                <br/>
                {/* <label htmlFor="pwd">비밀번호</label><br/> */}
                <input 
                        className={ SignupStyle.signPassword }
                        type="password"
                        name="pwd"
                        placeholder="비밀번호를 입력하세요"
                        onChange={ onChangeHandler }        
                /><br/>
                {/* <label htmlFor="pwd">그룹명</label><br/> */}
                <input 
                        className={ SignupStyle.signName }
                        type="text"
                        name="name"
                        placeholder="그룹명을 입력하세요"
                        onChange={ onChangeHandler }        
                /><br/>

                <button 
                        type="submit"
                        onClick={ onClickHandler }
                        className={ SignupStyle.signup }
                >
                    회원가입
                </button>
            </div>
        </div>
    );
}

export default Signup;