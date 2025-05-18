import React from "react";
import { User } from "lucide-react";

const Navbar = () => {
  return (
    <header className="bg-gray-100 text-black shadow-md padding">
      <div className="max-w-7xl mx-auto px-4 py-4 flex items-center justify-between">
        {/* MENÚ IZQUIERDA */}
        <nav className="hidden md:flex gap-10 text-lg absolute left-0 p-7 font-navbar">
          <a href="/libros" className="hover:underline p-3">Libros</a>
          <a href="/autores" className="hover:underline p-3">Autores</a>
          <a href="/categorias" className="hover:underline p-3">Categorías</a>
        </nav>

        {/* LOGO CENTRO */}
        <div className="mx-auto text-4xl font-logo tracking-widest">RAYA</div>

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
