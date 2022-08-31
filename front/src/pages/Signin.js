import axios from "axios";
import { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { INIT_GROUP_INFO, SET_GROUP_INFO } from "../modules/GroupModule";
function Signin() {

    const groupInfo = useSelector(state => state.groupReducer);
    const dispatch = useDispatch();

    const onChangeHandler = (e) => {
        dispatch({ type: [SET_GROUP_INFO], payload: e.target});
        console.log(groupInfo[0])
    }

    const onClickHandler = async (e) => {
        const signInMember = await axios({
            method: 'post',
            url: 'http://', // 서버 주소로 변경
            data: {
                groupId: groupInfo[0].group_id,
                groupPwd: groupInfo[0].group_pwd,
            }
        })

        console.log('로그인 정보 :', signInMember)
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