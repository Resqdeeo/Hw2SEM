import Card from "../Card";
import NotFound from "../NotFound";
import './List.css'
const List = ({pokemons}) => {
    return (
        <>
            {(pokemons.length === 0) && <NotFound/>}
        
            <div className="pokemon-list">
                <div className="pokemon-list-wrapper">
                    {pokemons.map(pokemon => (<Card pokemon={pokemon} key={pokemon.id}/>))}
                </div>
            </div>
        </>
        )

};

export default List;