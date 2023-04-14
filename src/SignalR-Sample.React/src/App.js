import './App.css';
import { Routes, Route } from "react-router-dom";
import Login from './features/login';
import Inbox from './features/inbox';
import SendMessage from './features/message';

function App() {
  return (
    <Routes>
                  <Route path="/" element={<Login />} />
                  <Route path="/inbox" element={<Inbox />} />
                  <Route path="/send-message" element={<SendMessage />} />
    </Routes>
  );
}

export default App;
