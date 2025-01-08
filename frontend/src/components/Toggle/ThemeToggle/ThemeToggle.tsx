import {GoSun, GoMoon} from "react-icons/go";
import {useThemeStore} from "@/stores/useThemeStore";
import styles from './ThemeToggle.module.scss';

export const ThemeToggle = () => {
    const currTheme = useThemeStore((state) => state.theme);
    const toggleTheme = useThemeStore((state) => state.switchTheme);

    return (
        <div onClick={toggleTheme}
             role="button"
             aria-label={`Switch to ${currTheme === "dark" ? 'light' : 'dark'} theme`}
             className={`${styles.toggle} ${currTheme === "dark" ? styles.active : ''}`}>
            <GoSun className={styles.sun}/>
            <GoMoon className={styles.moon}/>
        </div>
    );
};

export default ThemeToggle;