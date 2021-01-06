import React from 'react';
import logo from  '../../assests/logo.svg'
import './styles.css';

const Header = ({ title }) => (
  <header>
    <div className="col-md-4">
      <img src={logo} alt="Ecoleta" />
    </div>
    <div className="col-md-8">
      <h1 className="font-weight-bold">{title?title:'Escolha um Título'}</h1>
    </div>
  </header>
);

export default Header;