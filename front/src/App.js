import { BrowserRouter, Route, Routes } from "react-router-dom";
import { CookiesProvider } from "react-cookie";
import AppStyle from './styles/App.module.css';
import Layout from "./layouts/Layout";
import Main from "./pages/Main";
import Signin from "./pages/Signin";
import Signup from "./pages/Signup";
import ShowHephaistos from "./pages/ShowHephaistos";
import ShowSearchHephaistos from "./pages/ShowSearchHephaistos";
import MyPage from "./pages/MyPage";
import Projects from "./pages/Projects";
import Guide from "./pages/Guide";

function App() {
  return (
    <div className={ AppStyle.app }>
      <CookiesProvider>
        <BrowserRouter>
          <Routes>
              <Route path="/" element={ <Layout/> }>
                <Route index element={ <Main/> } />
                <Route path="/mypage" element={ <MyPage/>}/> 
                <Route path="/projects" element={ <Projects/>}/>
                <Route path="/guide" element={ <Guide/>}/>
              </Route>
              <Route path="/signin" element={ <Signin/> }/>
              <Route path="/signup" element={ <Signup/> }/>        
              <Route path="/hephaistos">
                <Route index element={ <ShowHephaistos/> }/>
                <Route path="search" element={ <ShowSearchHephaistos/> }/>
              </Route>
               

            </Routes>
          </BrowserRouter>
      </CookiesProvider>
    </div>
  );
}

export default App;
