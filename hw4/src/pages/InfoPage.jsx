import {useParams} from "react-router-dom";
import Header from "../components/InfoPage/Header";
import Info from "../components/InfoPage/Info";

const InfoPage = () => {
    const {name} = useParams()

    return <div>
        <Header/>
        <Info name={name}/>
    </div>
}

export default InfoPage