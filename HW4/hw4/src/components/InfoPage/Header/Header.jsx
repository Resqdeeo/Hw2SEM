import React from "react";
import pokeball from "../../../assets/Pokeball.png";
import left from "../../../assets/left.png"
import {Link} from "react-router-dom";
import './Header.css'

const Header = () => {
    return (
        <header className="pokemon-header">
            <div className="pokemon-header-items">
                <Link to="/">
                    <img  src={left} alt="" />
                </Link>
                <img className="pokemon-header-pokeball-image" src={pokeball} alt="Pokeball"/>
            </div>
        </header>
    )
}

export default Header;