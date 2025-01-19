import AppRoutes from "./routes/AppRoutes.tsx";
import {useThemeStore} from "./stores/useThemeStore";
import {NavBar, Footer} from "@components/navigation";
import {ThemeTypes} from "./types";
import {AuthProvider} from "@/provider/AuthContext.tsx";
import ErrorFallback from "@components/ErrorFallback/ErrorFallback.tsx";
import {ErrorBoundary} from "react-error-boundary";


function App() {
    const currTheme: ThemeTypes = useThemeStore((state) => state.theme);
    document.documentElement.setAttribute("data-theme", currTheme);

    return (
        <main className={'app'}>
            <AuthProvider>
                <NavBar/>
                <div className={'container'}>
                    <ErrorBoundary FallbackComponent={ErrorFallback}>
                        <AppRoutes/>
                    </ErrorBoundary>
                    <Footer/>
                </div>
            </AuthProvider>
        </main>

    )
}

export default App
