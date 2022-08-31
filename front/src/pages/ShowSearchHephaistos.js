import axios from 'axios';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate, useSearchParams } from 'react-router-dom'; 
import { INIT_MODEL_INFO, SET_SEARCH_KEY, SET_SEARCH_TYPE } from '../modules/ModelModule';
import HephaistosStyle from '../styles/Hephaistos.module.css';

function ShowSearchHephaistos() {

    const [searchParams] = useSearchParams();

    const modelInfo = useSelector(state => state.modelReducer);
    const navigate = useNavigate();
    const dispatch = useDispatch();

    const searchKey = searchParams.get('searchKey');
    const searchType = searchParams.get('searchType');

    const onChangeKeyHandler = (e) => {
        dispatch({ type: [SET_SEARCH_KEY], payload: e.target});
        console.log(modelInfo[0])
    }

    const onChangeTypeHandler = (e) => {
        dispatch({ type: [SET_SEARCH_TYPE], payload: e.target});
        console.log(modelInfo[0])
    }

    const onClickHandler = () => {
        navigate(`/hephaistos/search?searchType=${ modelInfo[0].search_type }&searchKey=${ modelInfo[0].search_key }`)
    }

    const onKeyUpHandler = () => {
        if(window.event.keyCode==13) {
            onClickHandler();
        }
    };

    useEffect(
        () => {
            console.log(searchKey, searchType)
            dispatch({ type: [INIT_MODEL_INFO]});
            //console.log(modelInfo[0])
            //axios({
                //method: "get"
                //url: "URL",
                //param: {
                //  searchKey: searchKey
                //  searchType: search    
                //} // 안보내도 URL에서 그냥 가져 올 수 있는 정보?
            //});
        }, [searchKey, searchParams]
    )

    return(
        <div>
            <label htmlFor="searchKey">검색</label><br/>
            <input 
                    type='text'
                    name='searchKey'
                    placeholder='검색어를 입력하세요'
                    onChange={ onChangeKeyHandler }
                    onKeyUp={ onKeyUpHandler }/>
            <select name='searchType' onChange={ onChangeTypeHandler }>
                <option value="선택">-- 선택 --</option>
                <option value="선택">그룹명</option>
                <option value="선택">모델명</option>
            </select>
            <button type='submit' onClick={ onClickHandler }>검색</button>
            <h1 className={ HephaistosStyle.unityApp }>UNITY APP LIST</h1>
        </div>
    )
}

export default ShowSearchHephaistos;