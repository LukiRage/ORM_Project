import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import jwt_decode from 'jwt-decode';
import './Login.css'; // Dodanie importu pliku CSS

const Login = () => {
  const navigate = useNavigate();
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post('http://localhost:8000/api/users/authenticate', {
        username,
        password
      });

      if (response.data) {
        const { token } = response.data;
        localStorage.setItem('token', token);

        const decodedToken = jwt_decode(token);

      // Przekierowanie użytkownika do odpowiedniego miejsca na podstawie jego roli
      if (decodedToken.role.includes('admin')) {
        navigate('/adminpanel');
      } else if (decodedToken.role.includes('user','number')) {
        navigate('/userpanel'); // Zmień to na odpowiednią ścieżkę dla użytkowników
      }
        setError(''); // Wyczyszczenie ewentualnego błędu logowania
      } else {
        throw new Error();
      }
    } catch (error) {
      setError('Username or password is incorrect.');
    }
  };

  return (
    <div className="login-container">
      <form onSubmit={handleSubmit}>
        <label htmlFor="username"><h4>Username</h4></label>
        <input
          type="text"
          id="username"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          placeholder="Username"
          required
        />
        <label htmlFor="password"><h4>Password</h4></label>
        <input
          type="password"
          id="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          placeholder="Password"
          required
        />
        <button type="submit">Login</button>
        {error && <p className="error">{error}</p>}
      </form>
    </div>
  );
};

export default Login;
