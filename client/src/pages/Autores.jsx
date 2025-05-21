import React, { useEffect, useState } from 'react';

const Autores = () => {
  const [autores, setAutores] = useState([]);

  useEffect(() => {
    fetch("http://localhost:55221/api/autores/completos") // Esta ruta debe devolver nombre, imagen, frase/biografía y libros
      .then(res => res.json())
      .then(data => setAutores(data))
      .catch(err => console.error("Error al cargar autores:", err));
  }, []);

  return (
    <section className="p-[10%] pt-0">
      <h2 className="text-3xl font-logo mb-6 mt-7 pl-3">Autores</h2>
      <div className="w-[60%] border-t-4 border-dotted border-black mx-4 mb-6 scale-x-100"></div>

      <div className="grid grid-cols-1 md:grid-cols-2 gap-x-8 gap-y-10">
        {autores.map(autor => (
          <div key={autor.id} className="bg-white rounded shadow p-6 flex flex-col md:flex-row items-center gap-6 m-0">
            {/* Imagen redonda */}
            <img
              src={`http://localhost:55221${autor.imagenUrl}`}
              alt={autor.nombre}
              className="w-40 h-40 object-cover rounded-full grayscale hover:grayscale-0 transition duration-500"
            />

            {/* Frase o biografía */}
            <div className="flex-1">
              <h3 className="text-xl font-logo mb-2">{autor.nombre}</h3>
              <p className="italic text-gray-700 mb-4">"{autor.biografia || 'Sin frase disponible.'}"</p>

              {/* Libros del autor */}
              <div className="flex gap-4 justify-start">
                {autor.libros?.slice(0, 3).map(libro => (
                  <img
                    key={libro.isbn}
                    src={`http://localhost:55221${libro.imagenUrl}`}
                    alt={libro.titulo}
                    title={libro.titulo}
                    className="w-20 h-28 object-contain rounded shadow"
                  />
                ))}
              </div>
            </div>
          </div>
        ))}
      </div>
    </section>
  );
};

export default Autores;
