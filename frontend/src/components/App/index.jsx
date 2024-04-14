import React, { useState } from 'react'; // import useState
import Login from '../Login';
import Register from '../Register';
import AdminPanel from '../AdminPanel';
import UserPanel from '../UserPanel'; // upewnij się, że ten plik istnieje

const App = () => {
  const [form, setForm] = useState('login');
  const userType = localStorage.getItem('userType');

  if (!userType) {
    return form === 'login' ? 
      <div>
        <Login />
        <button onClick={() => setForm('register')}>Go to Register</button>
      </div> 
      :
      <div>
        <Register />
        <button onClick={() => setForm('login')}>Go to Login</button>
      </div>
  }

  if (userType === 'admin') {
    return <AdminPanel />;
  }

  if (userType === 'user') {
    return <UserPanel />;
  }
};

export default App;