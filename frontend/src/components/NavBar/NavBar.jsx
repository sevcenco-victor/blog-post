import {NavLink} from "react-router-dom";
import ThemeToggle from "../Toggle/ThemeToggle/ThemeToggle.jsx";
import styles from './NavBar.module.scss'

const NavBar = ({theme, setTheme}) => {
    return (
        <nav className={`container ${styles['nav']}`}>
            <h3 className={styles['nav__logo']}>Blog Page</h3>
            <ul className={styles['nav__list']}>
                <NavLink to='/'
                         className={({isActive}) => 
                             `${styles['nav__item']} 
                             ${isActive ? styles['nav__item--active'] : ''}`}>
                    Blog
                </NavLink>
                <NavLink to='projects'
                         className={({isActive}) => 
                             `${styles['nav__item']} 
                             ${isActive ? styles['nav__item--active'] : ''}`}>
                    Projects
                </NavLink>
                <NavLink to='about'
                         className={({isActive}) => 
                             `${styles['nav__item']} 
                             ${isActive ? styles['nav__item--active'] : ''}`}>
                    About
                </NavLink>
                <NavLink to='newsletter'
                         className={({isActive}) => 
                             `${styles['nav__item']} 
                             ${isActive ? styles['nav__item--active'] : ''}`}>
                    Newsletter
                </NavLink>
                <li>
                    <ThemeToggle theme={theme} setTheme={setTheme}/>
                </li>
            </ul>
        </nav>
    );
};

export default NavBar;