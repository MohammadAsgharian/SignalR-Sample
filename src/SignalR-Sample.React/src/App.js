import './App.css';
import { Routes, Route } from "react-router-dom";
import Login from './features/login';
import Inbox from './features/inbox';

function App() {
  return (
    <Routes>
                  <Route path="/" element={<Login />} />
                  <Route path="/inbox" element={<Inbox />} />
    </Routes>
  );
}

export default App;
