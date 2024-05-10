import './App.css';
import SearchPage from './pages/SearchPage';
import {BrowserRouter, Route, Routes} from "react-router-dom";


function App() {
  return (
    <BrowserRouter>
      <SearchPage></SearchPage>
    </BrowserRouter>
  );
}

export default App;
