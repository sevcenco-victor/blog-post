import NavBar from "./components/NavBar/NavBar";
import AppRouter from "./routers/AppRouter";
import Footer from "./components/Footer/Footer";
import {useState} from "react";
import './styles/styles.css';

function App() {
    const userPreference = window.matchMedia("(prefers-color-scheme: dark)").matches;
    const [theme, setTheme] = useState(userPreference ? "dark" : "light");
    document.documentElement.setAttribute("data-theme", theme);

    return (
        <div className={'app'}>
            <NavBar theme={theme} setTheme={setTheme}/>
            <div className={'container'}>
                <AppRouter/>
                <Footer/>
            </div>
        </div>
    )
}

export default App
