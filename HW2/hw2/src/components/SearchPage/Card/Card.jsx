import React from "react"
import './Card.css'
import Type from "../Type"
import {Link} from "react-router-dom";

const Card = ({pokemon}) => {
    if (!pokemon) {
        return <div></div>
    }

    return (
        <Link to={`/pokemon/${pokemon.name}`}>
            <div className="pokemon-card">
                <div className="card-header">
                    <div className="pokemon-name">
                        {pokemon.name[0].toUpperCase() + pokemon?.name.slice(1)}
                    </div>
                    <div className="pokemon-id">
                        #{pokemon.id.toString().padStart(3, '0')}
                    </div>
                </div>
                <div className="card-content">
                    <img alt={pokemon.name} className="card-image" src={pokemon.sprites.other.home.front_default}/>
                </div>
                <div className="card-footer">
                    <Type types={pokemon.types}/>
                </div>
            </div>
        </Link>
    );
    
}

export default Card