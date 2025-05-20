import React, { useEffect, useState } from 'react';

const Libros = () => {
  const [libros, setLibros] = useState([]);

  useEffect(() => {
    fetch("http://localhost:55221/api/libros/todos")
      .then(res => res.json())
      .then(data => {
        console.log("Todos los libros:", data);
        setLibros(data);
      })
      .catch(err => console.error("Error al cargar libros:", err));
  }, []);

  return (
    <section className="p-[16%] pt-0">
      <h2 className="text-3xl font-logo mb-6 mt-7 pl-4">Libros</h2>
      <div className="w-[60%] border-t-4 border-dotted border-black mx-4 mb-6 scale-x-100"></div>

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
    </section>
  );
};

export default Libros;
