import axios from "axios";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { INIT_GROUP_INFO, SET_GROUP_INFO } from "../modules/GroupModule";

function Signup() {

    const groupInfo = useSelector(state => state.groupReducer);
    const dispatch = useDispatch();

    const onChangeHandler = (e) => {
        dispatch({ type: [SET_GROUP_INFO], payload: e.target})
        console.log(groupInfo[0])
    }

    const onClickHandler = async (e) => {
        const signUpMember = await axios({
            method: 'post',
            url: 'http://', // 서버 주소로 변경
            data: {
                groupId: groupInfo[0].group_id,
                groupPwd: groupInfo[0].group_pwd,
            }
        })

        console.log('회원가입 정보 :', signUpMember)
    }

    useEffect(
        () => {
            dispatch({ type: [INIT_GROUP_INFO] });
        }, []
    );

    return (
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
            <label htmlFor="pwd">그룹명</label><br/>
            <input 
                    type="text"
                    name="name"
                    placeholder="그룹명을 입력하세요"
                    onChange={ onChangeHandler }        
            /><br/>

            <button 
                    type="submit"
                    onClick={ onClickHandler }
            >
                회원가입
            </button>
        </div>
    );
}

export default Signup;