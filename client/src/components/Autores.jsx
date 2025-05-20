import React, { useEffect, useState } from 'react';

const Autores = () => {
    const [autores, setAutores] = useState([]);

    useEffect(() => {
        fetch("http://localhost:55221/api/autores/destacados/3")
                .then(res => res.json())
                .then(data => {
            console.log("Datos recibidos:", data);
            setAutores(data);
        }).catch(err => console.error(err));

    }, []);

    return (
        <section className="p-6 mt-8">
            <h2 className="text-2xl font-logo mb-4 mt-6 pl-4">Autores</h2>
            <div className="w-[60%] border-t-4 border-dotted border-black mx-4 mb-4 scale-x-100"></div>

            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-3 m-3 pt-6 pl-10 pr-10">
                {autores.map(autor => (
                    <div key={autor.Id} className="bg-white p-3 text-center">
                        <img className="w-[230px] h-[230px] object-cover rounded-full grayscale hover:grayscale-0 transition duration-500 mx-auto mb-2 mt-3" 
                            src={`http://localhost:55221${autor.imagenUrl}`} 
                            alt={autor.nombre}/>

                        <h3 className="text-lg font-logo text-[16px]">{autor.nombre}</h3>
                    </div>
                ))}
            </div>
        </section>
    );
};

export default Autores;
