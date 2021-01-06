import React from 'react';
import Header from './components/header';
import LocaisBox from './components/locais';
import './App.css'
import Mapa from './components/mapa'

function App() {
  return (
	<div className="container">
		<div className="container">
			<Mapa />
		</div>
		<div className="container">
			<br />
			<Header title="Projeto Locais de Reciclagem"/>
			<br/>
			<LocaisBox />
		</div>
    </div>
  );
}

export default App