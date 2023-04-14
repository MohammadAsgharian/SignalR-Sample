import './App.css';
import { Routes, Route } from "react-router-dom";
import Login from './features/login';
import InboxMessage from './features/message/inbox';
import SendMessage from './features/message/outbox';

function App() {
  return (
    <Routes>
                  <Route path="/" element={<Login />} />
                  <Route path="/inbox" element={<InboxMessage />} />
                  <Route path="/send-message" element={<SendMessage />} />
    </Routes>
  );
}

export default App;
