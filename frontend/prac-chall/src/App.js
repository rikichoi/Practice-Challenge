import './App.css';
import SignUp from './components/SignUp';
import Entry from './components/Entry';
import Login from './components/Login';
import Home from './components/Home';
import {
  BrowserRouter as Router,
  Routes,
  Route
} from "react-router-dom";
import {LoginContext} from './helper/Context';
import React, {useState} from 'react';

function App() {
  const [userID, setUserID] = useState();

  return (
    <LoginContext.Provider value={{ userID, setUserID }}>
    <Router>
      <Routes>
        <Route exact path="/" element={<Entry />}/>
        <Route exact path="/login" element={<Login />}/>
        <Route exact path="/signup" element={<SignUp />}/>
        <Route exact path="/home" element={<Home />}/>
      </Routes>
    </Router>
    </LoginContext.Provider>
  );
}

export default App;
