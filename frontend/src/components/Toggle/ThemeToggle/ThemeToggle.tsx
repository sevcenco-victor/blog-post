import {GoSun} from "react-icons/go";
import {GoMoon} from "react-icons/go";
import {useThemeStore} from "../../../stores/useThemeStore.ts";
import styles from './ThemeToggle.module.scss';

const ThemeToggle = () => {
    const isDarkTheme = useThemeStore((state) => state.isDark);
    const toggleTheme = useThemeStore((state) => state.switchTheme);

    return (
        <div onClick={toggleTheme}
             role="button"
             aria-label={`Switch to ${isDarkTheme ? 'light' : 'dark'} theme`}
             className={`${styles['toggle']} ${isDarkTheme ? styles['toggle--is-active'] : ''}`}>
            <GoSun className={styles['toggle__sun']}/>
            <GoMoon className={styles['toggle__moon']}/>
        </div>
    );
};

export default ThemeToggle;