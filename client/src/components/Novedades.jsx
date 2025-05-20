import React, { useEffect, useState } from 'react';

const Novedades = () => {
    const [libros, setLibros] = useState([]);

    useEffect(() => {
        fetch("http://localhost:55221/api/libros/ultimos/4")
                .then(res => res.json())
                .then(data => {
            console.log("Datos recibidos:", data);
            setLibros(data);
        }).catch(err => console.error(err));

    }, []);

    return (
        <section className="p-6 pb-0">
            <h2 className="text-2xl font-logo mb-2 mt-5 pl-4 pb-2">Novedades</h2>
            <div className="w-[60%] border-t-4 border-dotted border-black mx-4 mb-4 scale-x-100"></div>

            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-4 gap-4 m-3 mb-0 pt-6">
                {libros.map(libro => (
                    <div key={libro.ISBN} className="bg-white p-3 pb-0 text-center transition-transform duration-300 mt-3 hover:scale-105">
                        <a href="http://">
                            <img className="w-full h-[360px] object-contain rounded mb-2" 
                                src={`http://localhost:55221${libro.imagenUrl}`} 
                                alt={libro.titulo} />
                        </a>
                        <h3 className="text-lg font-logo text-[16px]">{libro.titulo}</h3>
                    </div>
                ))}
            </div>
        </section>
    );
};

export default Novedades;
