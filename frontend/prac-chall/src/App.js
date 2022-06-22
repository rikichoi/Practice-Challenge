import './App.css';
import SignUp from './components/SignUp';
import Entry from './components/Entry';
import Login from './components/Login';
import Pets from './components/Pets';
import Procedures from './components/Procedures';
import Treatments from './components/Treatments';
import {
  BrowserRouter as Router,
  Routes,
  Route
} from "react-router-dom";

function App() {
  return (
    <Router>
      <Routes>
        <Route exact path="/" element={<Entry />}/>
        <Route exact path="login" element={<Login />}/>
        <Route exact path="signup" element={<SignUp />}/>
        <Route exact path="pets" element={<Pets />}/>
        <Route exact path="procedures" element={<Procedures />}/>
        <Route exact path="treatments" element={<Treatments />}/>
      </Routes>
    </Router>
  );
}

export default App;
