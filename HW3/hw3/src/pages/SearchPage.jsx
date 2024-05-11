import Header from "../components/SearchPage/Header";
import React, {useEffect, useState} from "react";
import NotFound from "../components/SearchPage/NotFound";
import List from "../components/SearchPage/List";
import ClipLoader from 'react-spinners/ClipLoader'


const SearchPage = () => {
    const [allPokemons, setAllPokemons] = useState([])
    const [searchResults, setSearchResults] = useState([]);
    const [searchText, setSearchText] = useState('');
    const [isSearching, setAsSearching] = useState(false)
    const [offset, setOffset] = useState(0);
    const [fetching, setFetching] = useState(true)

    useEffect(() => {
        document.addEventListener('scroll', scrollHandler)

        return function () {
            document.removeEventListener('scroll', scrollHandler)
        }
    })

    const scrollHandler = (e) => {
        if (e.target.documentElement.scrollHeight - (e.target.documentElement.scrollTop + window.innerHeight) < 600 && !fetching) {
            setFetching(true)
        }
    }

    useEffect(() => {
        if (fetching) {
            fetch(`http://localhost:4379/api/Pokemon?limit=20&offset=${offset}`)
                .then(response => response.json() )
                .then(data => {
                    data.pokemons.map(pokemon => fetchPokemonData(pokemon));
                    setOffset(prevOffset => prevOffset + 10)
                    checkIfFetchingNeeded()
                })
                .catch(error => console.error('Error fetching initial data:', error));
        }
    }, [fetching, offset]);

    const checkIfFetchingNeeded = () => {
        if (searchResults.length === 0) {
            const visiblePokemons = Object.values(allPokemons).filter(pokemon =>
                pokemon.name.includes(searchText.toLowerCase())
            );

            if (visiblePokemons.length === 0) {
                return
            }
            if (visiblePokemons.length <= 70) {
                setFetching(true);
            } else {
                setFetching(false);
            }
        } else {
            const visiblePokemons = Object.values(searchResults);
            if (visiblePokemons.length <= 70) {
                setFetching(true);
            } else {
                setFetching(false);
            }
        }};

    const fetchPokemonData = (pokemon) => {
        fetch(`http://localhost:4379/api/Pokemon/${pokemon.name}`)
            .then(response => response.json())
            .then(pokemonData => {
                    if (searchText && pokemonData.name.includes(searchText.toLowerCase())) {
                        setSearchResults(prevAllPokemons => ({
                            ...prevAllPokemons,
                            [pokemonData.id]: pokemonData
                        }))
                    } else {
                        setAllPokemons(prevAllPokemons => ({
                            ...prevAllPokemons,
                            [pokemonData.id]: pokemonData
                        }));
                    }

                }
            )
            .catch(error => console.error('Error fetching data for', pokemon.name, ':', error))
    };

    const handleChange = event => {
        setSearchText(event.target.value);
    };

    const handleSubmit = () => {
        setAsSearching(true)
        if (searchText) {
            let results = Object.values(allPokemons).filter(pokemon =>
                pokemon.name.includes(searchText.toLowerCase()))
            setSearchResults(results)
        } else {
            setSearchResults([])
            setAllPokemons([])
            setAsSearching(false)
            setFetching(true)
            setOffset(0)
        }
    };

    useEffect(() => {
        checkIfFetchingNeeded();
    }, [searchResults]);

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
