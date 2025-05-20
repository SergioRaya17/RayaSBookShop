import React from "react";
import { User } from "lucide-react";
import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <header className="sticky top-0 z-50 bg-gray-100 text-black shadow-md">
      <div className="max-w-7xl mx-auto px-4 py-4 flex items-center justify-between">
        {/* MENÚ IZQUIERDA */}
        <nav className="hidden md:flex gap-10 text-lg absolute left-0 p-7 font-navbar">
          <Link to="/libros" className="hover:underline p-3">Libros</Link>
          <Link to="/autores" className="hover:underline p-3">Autores</Link>
          <Link to="/categorias" className="hover:underline p-3">Categorías</Link>
        </nav>

        {/* LOGO CENTRO */}
        <div className="mx-auto text-4xl font-logo tracking-widest"><a href="../">RAYA</a></div>

        {/* ICONO PERFIL DERECHA */}
        <div className="absolute right-0 p-7">
        <button
            className="text-gray-700 text-3xl hover:text-gray-500"
            title="Perfil"
        >
            
        <User
        className="w-6 h-7 text-black hover:text-gray-700 transition duration-200 mt-2"
        strokeWidth={1}
        />

        </button>
        </div>
      </div>
    </header>
  );
};

export default Navbar;
