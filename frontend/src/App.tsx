import NavBar from "./components/NavBar/NavBar";
import AppRouter from "./routers/AppRouter";
import Footer from "./components/Footer/Footer";
import {useThemeStore} from "./stores/useThemeStore";

function App() {
    const isDarkTheme = useThemeStore((state) => state.isDark);
    document.documentElement.setAttribute("data-theme", isDarkTheme ? "dark" : "light");

    return (
        <div className={'app'}>
            <NavBar/>
            <div className={'container'}>
                <AppRouter/>
                <Footer/>
            </div>
        </div>
    )
}

export default App
