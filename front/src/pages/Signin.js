import axios from "axios";
import { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { INIT_INFO, SET_INFO } from "../modules/GroupModule";
function Signin() {

    const groupInfo = useSelector(state => state.groupReducer);
    const dispatch = useDispatch();

    const onChangeHandler = (e) => {
        dispatch({ type: [SET_INFO], payload: e.target})
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
            dispatch({ type: [INIT_INFO] });
        }, []
    );

    return (
        <div>
            <label htmlFor="id">아이디</label><br/>
            <input 
                    type="text"
                    name="id"
                    onChange={ onChangeHandler }
            />
            <br/>
            <label htmlFor="pwd">비밀번호</label><br/>
            <input 
                    type="password"
                    name="pwd"
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