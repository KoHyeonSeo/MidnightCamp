import MainStyle from '../styles/Main.module.css';
import { NavLink, useNavigate } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { writeBoardAlert } from '../components/items/alertDesign';

function Main() {

    // 이미지 배치만 => 완료

    const onClickStart = async () => {
        if(!loginInfo[0].login_id) {
            writeBoardAlert();
            navigate('/signin');
        } else {
            navigate('/mypage');
        }
    }

    const onClickGuide = () => {

    }

    const loginInfo = useSelector(state => state.loginReducer);
    const navigate = useNavigate();

    return(
        <div className={ MainStyle.main }>
            {/* <h1 className={ MainStyle.h1 }>Main Page</h1> */}
            <img className={ MainStyle.breif } src={require("../static/images/text.png")}/>
            {/* <img className={ MainStyle.start } onClick={ onClickStart } src={require("../static/images/join_s.png")}/> */}
            {/* <img className={ MainStyle.guide } onClick={ onClickGuide } src={require("../static/images/join_d.png")}/> */}
            <div className={ MainStyle.start } onClick={ onClickStart }>바로 시작하기</div>
            <NavLink className={ MainStyle.guide } to='/guide'>가이드 보기</NavLink>
            <img className={ MainStyle.monito } src={require("../static/images/main.png")}/>
        </div>
    );
}

export default Main;