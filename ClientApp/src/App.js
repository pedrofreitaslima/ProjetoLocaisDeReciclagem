import React from 'react';
import Header from './components/header';
import LocaisBox from './components/locais';
import './App.css'
import Mapa from './components/mapa'

function App() {
  return (
		<div className="container">
			<Header title="Projeto Locais de Reciclagem"/>
			<br/>
			<Mapa />
			<br />
			<LocaisBox />
    </div>
  );
}

export default App