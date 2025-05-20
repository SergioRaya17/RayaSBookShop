import React from 'react';
import Novedades from '../components/Novedades';
import Navbar from '../components/Navbar';
import Autores from '../components/Autores';


const Home = () => {
    return (
        <div className='p-[16%] pt-0'>
            <Novedades/>
            <Autores/>
        </div>
    );
};

export default Home;
