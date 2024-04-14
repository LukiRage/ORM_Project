import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Login from './components/Login';
import AdminPanel from './components/AdminPanel';
import UserPanel from './components/UserPanel';
const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/adminpanel" element={<AdminPanel />} />
        <Route path="/userpanel" element={<UserPanel />} />
      </Routes>
    </Router>
  );
};

export default App;
