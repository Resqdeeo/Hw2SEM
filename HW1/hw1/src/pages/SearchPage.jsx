import Header from "../components/Header";
import React, {useEffect, useState} from "react";
import NotFound from "../components/NotFound";
import List from "../components/List";
import ClipLoader from 'react-spinners/ClipLoader'


const SearchPage = () => {
    const [allPokemons, setAllPokemons] = useState([])
    const [searchResults, setSearchResults] = useState([]);
    const [searchText, setSearchText] = useState('');
    const [isSearching, setSearching] = useState(false)

    useEffect(() => {
            fetch(`https://pokeapi.co/api/v2/pokemon?limit=1000`)
                .then(response => response.json())
                .then(data => {
                    data.results.map(pokemon => fetchPokemonData(pokemon));
                })
                .catch(error => console.error('Error fetching initial data:', error))
        }
    )


    const fetchPokemonData = (pokemon) => {
        fetch(pokemon.url)
            .then(response => response.json())
            .then(pokemonData => {
                    setAllPokemons(prevAllPokemons => ({
                        ...prevAllPokemons,
                        [pokemonData.id]: pokemonData
                    }))
                }
            )
            .catch(error => console.error('Error fetching data for', pokemon.name, ':', error))
    };

    const handleChange = event => {
        setSearchText(event.target.value);
    };

    const handleSubmit = () => {
        if (searchText) {
            setSearching(true)
            let results = Object.values(allPokemons).filter(pokemon =>
                pokemon.name.includes(searchText.toLowerCase()))
            setSearchResults(results)
        } else {
            setSearching(false)
            setSearchResults([])
        }

        console.log(searchResults)
    };

    return (
        <>
            <Header inputText={searchText} handleChange={handleChange} handleSubmit={handleSubmit}/>
            <div className="search-page-content">
                {isSearching ?
                    (searchResults.length !== 0 ?
                            (
                                <List pokemons={Object.values(searchResults)}/>
                            ) : (
                                <NotFound/>
                            )
                    ) : (
                        allPokemons.length !== 0 ?
                            (
                                <List pokemons={Object.values(allPokemons)}/>
                            ) : (
                                <ClipLoader color="#000000"/>)
                    )
                }
            </div>
        </>
    );
}

export default SearchPage;