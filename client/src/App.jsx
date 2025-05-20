import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

import Navbar from './components/Navbar';
import Home from './pages/Home';
import Libros from './pages/Libros';
import Autores from './pages/Autores';
import Categorias from './pages/Categorias';

const App = () => {
  return (
    <BrowserRouter>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/libros" element={<Libros />} />
        <Route path="/autores" element={<Autores />} />
        <Route path="/categorias" element={<Categorias />} />
      </Routes>
    </BrowserRouter>
  );
};

export default App;

