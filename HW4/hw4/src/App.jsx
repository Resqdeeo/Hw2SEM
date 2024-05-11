import './App.css';
import SearchPage from './pages/SearchPage';
import InfoPage from './pages/InfoPage';
import {BrowserRouter, Route, Routes} from "react-router-dom";


function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" Component={SearchPage} />
        <Route path="/pokemon/:name" Component={InfoPage} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;