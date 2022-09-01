import axios from 'axios';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate, useSearchParams } from 'react-router-dom';
import { Unity, useUnityContext } from 'react-unity-webgl';
import { SET_SEARCH_KEY, SET_SEARCH_RESULT } from '../modules/ModelModule';
import MyPageStyle from "../styles/MyPage.module.css";

function MyPage() {

    // 마이페이지
    const [searchParams] = useSearchParams();

    const modelInfo = useSelector(state => state.modelReducer);
    const navigate = useNavigate();
    const dispatch = useDispatch();

    // 유니티 빌드 파일 경로 입력 => UNITY APP 임베드
    const { unityProvider } = useUnityContext({
    // loaderUrl: "Build/Build.loader.js",
    // dataUrl: "Build/Build.data",
    // frameworkUrl: "Build/Build.framework.js",
    // codeUrl: "Build/Build.wasm",
    });

    const onChangeKeyHandler = (e) => {
        dispatch({ type: [SET_SEARCH_KEY], payload: e.target});
        console.log(modelInfo[0])
    }

    const onClickHandler = async () => {
        console.log(modelInfo[0])
        const result = await axios({
            method: 'get',
            url: `http://192.168.94.115:8888/model/search/?type=name&keyword=${ modelInfo[0].search_key }`
                // `http://192.168.1.51:8888/model/search/?type=name&keyword=${ modelInfo[0].search_key }`
        })
        // navigate(`/hephaistos/search?type=${ modelInfo[0].search_type }&keyword=${ modelInfo[0].search_key }`)
        console.log(result);
        dispatch({ type: [SET_SEARCH_RESULT], payload: result});
        console.log(modelInfo[0].search_result)
    }

    const onKeyUpHandler = () => {
        if(window.event.keyCode==13) {
            onClickHandler();
        }
    };

    return (
        <div className={ MyPageStyle.mypage }>
            <div className={ MyPageStyle.title }>My Project</div>
            {/* <img src="http://172.16.17.27:8888/sakura.jpg"/> */}
            <input 
                    className={ MyPageStyle.search }
                    type='text'
                    name='searchKey'
                    placeholder='검색어를 입력하세요'
                    onChange={ onChangeKeyHandler }
                    onKeyUp={ onKeyUpHandler }/>
            <div className={ MyPageStyle.list }>
                <ul>
                    <li className={ MyPageStyle.firstLi }><img className={ MyPageStyle.check } src={require("../static/images/체크박스_채움.png")}/>아파트
                    <img className={ MyPageStyle.more } src={require("../static/images/더보기버튼.png")}/></li>
                    <li><img className={ MyPageStyle.uncheck } src={require("../static/images/체크박스.png")}/>다리 기획안
                    <img className={ MyPageStyle.more } src={require("../static/images/더보기버튼.png")}/></li>
                    <li><img className={ MyPageStyle.uncheck } src={require("../static/images/체크박스.png")}/>프로토타입
                    <img className={ MyPageStyle.more } onMouseOver={() => { console.log('test')}} src={require("../static/images/더보기버튼.png")}/></li>
                    <li><img className={ MyPageStyle.uncheck } src={require("../static/images/체크박스.png")}/>돌다리
                    <img className={ MyPageStyle.more } src={require("../static/images/더보기버튼.png")}/></li>
                    <li><img className={ MyPageStyle.uncheck } src={require("../static/images/체크박스.png")}/>상상의 건물
                    <img className={ MyPageStyle.more } src={require("../static/images/더보기버튼.png")}/></li>
                </ul>
            </div>
            {/* <img className={ MyPageStyle.detail } src={require("../static/images/더보기상세창.png")}/> */}
            <img className={ MyPageStyle.mirror } src={require("../static/images/돋보기.png")}/>
            <img className={ MyPageStyle.logo } src={require("../static/images/logo2.png")}/>
            <Unity unityProvider={ unityProvider }
                className={ MyPageStyle.unity }
                style={{
                height: 600,
                width: 1000,
                border: "2px solid #231F44",
                background: "#231F44",
             }}/>
        </div>
    )
}

export default MyPage;