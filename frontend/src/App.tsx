import AppRoutes from "./routes/AppRoutes.tsx";
import {useThemeStore} from "./stores/useThemeStore";
import {NavBar, Footer} from "@components/navigation";
import {ThemeTypes} from "./types";

function App() {
    const currTheme: ThemeTypes = useThemeStore((state) => state.theme);
    document.documentElement.setAttribute("data-theme", currTheme);

    return (
        <div className={'app'}>
            <NavBar/>
            <div className={'container'}>
                <AppRoutes/>
                <Footer/>
            </div>
        </div>
    )
}

export default App
