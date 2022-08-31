import { NavLink } from 'react-router-dom';
import HeaderStyle from '../../styles/Header.module.css'

function Header() {

    return (
        <div className={ HeaderStyle.header }>
            <h1 className={ HeaderStyle.h1 }>Header</h1>
            <NavLink className={ HeaderStyle.signinButton } to="/signin">
                <button>로그인</button>
            </NavLink>
            <NavLink className={ HeaderStyle.signupButton } to="/signup">
                <button>회원가입</button>
            </NavLink>
        </div>
    );
}

export default Header;