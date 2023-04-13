import logo from './logo.svg';
import './App.css';
import { Routes, Route } from "react-router-dom";
import Login from './features/login';

function App() {
  return (
    <Routes>
                  <Route path="/" element={<Login />} />
                  <Route path="login" element={<Login />} />
    </Routes>
  );
}

export default App;
