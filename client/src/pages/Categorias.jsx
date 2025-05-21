import React, { useEffect, useState } from 'react';

const Categorias = () => {
  const [categorias, setCategorias] = useState([]);
  const [categoriaSeleccionada, setCategoriaSeleccionada] = useState(null);
  const [libros, setLibros] = useState([]);
  const [mostrarLista, setMostrarLista] = useState(false);

  useEffect(() => {
    fetch("http://localhost:55221/api/categorias")
      .then(res => res.json())
      .then(data => setCategorias(data))
      .catch(err => console.error("Error al cargar categorías:", err));
  }, []);

  useEffect(() => {
    if (categoriaSeleccionada) {
      fetch(`http://localhost:55221/api/categorias/${categoriaSeleccionada.id}/libros`)
        .then(res => res.json())
        .then(data => setLibros(data))
        .catch(err => console.error("Error al cargar libros por categoría:", err));
    }
  }, [categoriaSeleccionada]);

  return (
    <section className="p-[16%] pt-0">
      <div className="relative inline-block">
        <h2
          onClick={() => setMostrarLista(!mostrarLista)}
          className="text-3xl font-logo mb-4 mt-7 pl-4 cursor-pointer select-none flex items-center gap-2"
        >
          {categoriaSeleccionada ? categoriaSeleccionada.nombre : 'Categorías'}
          <span className={`transform transition-transform ${mostrarLista ? 'rotate-180' : ''}`}>
            ^
          </span>
        </h2>

        {mostrarLista && (
          <ul className="absolute bg-white shadow rounded mt-1 ml-4 z-10 w-64 border">
            {categorias.map(cat => (
              <li
                key={cat.id}
                className="p-2 hover:bg-gray-100 cursor-pointer"
                onClick={() => {
                  setCategoriaSeleccionada(cat);
                  setMostrarLista(false);
                }}
              >
                {cat.nombre}
              </li>
            ))}
          </ul>
        )}
      </div>

      <div className="w-[60%] border-t-4 border-dotted border-black mx-4 mb-6 scale-x-100"></div>

      {!categoriaSeleccionada ? (
        <p className="text-center italic text-gray-600 mt-[26%]">Selecciona una categoría</p>
      ) : (
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-5 gap-10 m-3">
          {libros.map(libro => (
            <div key={libro.isbn} className="bg-white h-[70%] p-3 text-center transition-transform duration-300 hover:scale-105">
              <img
                src={`http://localhost:55221${libro.imagenUrl}`}
                alt={libro.titulo}
                className="w-full h-[300px] object-contain rounded mb-2"
              />
              <h3 className="text-lg font-logo">{libro.titulo}</h3>
            </div>
          ))}
        </div>
      )}
    </section>
  );
};

export default Categorias;
