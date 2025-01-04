import {useState} from "react";
import {GoSun} from "react-icons/go";
import {GoMoon} from "react-icons/go";
import styles from './ThemeToggle.module.scss';

const ThemeToggle = ({theme, setTheme}) => {
    const [isActive, setIsActive] = useState(theme === 'dark');

    const handleToggle = () => {
        setTheme(!isActive ? 'dark' : 'light');
        setIsActive(!isActive);
    }

    return (
        <div onClick={() => handleToggle()}
             className={`${styles['toggle']} ${isActive ? styles['toggle--is-active'] : ''}`}>
            <GoSun className={styles['toggle__sun']}/>
            <GoMoon className={styles['toggle__moon']}/>
        </div>
    );
};

export default ThemeToggle;