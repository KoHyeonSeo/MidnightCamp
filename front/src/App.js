import { BrowserRouter, Route, Routes } from "react-router-dom";
import AppStyle from './styles/App.module.css';
import Layout from "./layouts/Layout";
import Main from "./pages/Main";
import Signin from "./pages/Signin";
import Signup from "./pages/Signup";
import ShowHephaistos from "./pages/ShowHephaistos";
import ShowSearchHephaistos from "./pages/ShowSearchHephaistos";

function App() {
  return (
    <div className={ AppStyle.app }>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={ <Layout/> }>
            <Route index element={ <Main/> } />
          </Route>
          <Route path="/signin" element={ <Signin/> }/>
          <Route path="/signup" element={ <Signup/> }/>        
          <Route path="/hephaistos">
            <Route index element={ <ShowHephaistos/> }/>
            <Route path="search" element={ <ShowSearchHephaistos/> }/>
          </Route>  
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
