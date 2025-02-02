import {useRef} from "react";
import {IoMdClose} from "react-icons/io";
import {Link, NavLink, useNavigate} from "react-router-dom";
import {RxHamburgerMenu} from "react-icons/rx";
import {ThemeToggle} from "@components/Toggle";
import styles from './NavBar.module.scss'

import {useAuth} from "@/hooks/useAuth.tsx";

export const NavBar = () => {
    const {user} = useAuth();
    const navigate = useNavigate();
    const navDialog = useRef<HTMLDialogElement | null>(null);

    const accountPath = user?.role === 'User' ? "/account" : "/admin";

    const openMobileNav = () => {
        if (navDialog.current) {
            navDialog.current.showModal();
        }
    };

    const closeMobileNav = () => {
        if (navDialog.current) {
            navDialog.current.close();
        }
    };

    return (
        <nav className={`container ${styles.nav}`}>
            <Link to={"/"}><h3 className={styles.navLogo}>Blog Page</h3></Link>
            <ul className={styles.list}>
                <NavLink to='/'
                         className={({isActive}) =>
                             `${styles.navItem} 
                             ${isActive ? styles.activeLink : ''}`}>
                    Blog
                </NavLink>
                <NavLink to='projects'
                         className={({isActive}) =>
                             `${styles.navItem} 
                             ${isActive ? styles.activeLink : ''}`}>
                    Projects
                </NavLink>
                <NavLink to='about'
                         className={({isActive}) =>
                             `${styles.navItem} 
                             ${isActive ? styles.activeLink : ''}`}>
                    About
                </NavLink>
                <NavLink to='newsletter'
                         className={({isActive}) =>
                             `${styles.navItem} 
                             ${isActive ? styles.activeLink : ''}`}>
                    Newsletter
                </NavLink>
                {user
                    ?
                    <NavLink to={accountPath}
                             className={({isActive}) =>
                                 `${styles.navItem} 
                             ${isActive ? styles.activeLink : ''}`}
                             onClick={() => navigate(accountPath)}
                    >
                        Account
                    </NavLink>
                    : <NavLink to='login'
                               className={({isActive}) =>
                                   `${styles.navItem} 
                             ${isActive ? styles.activeLink : ''}`}>
                        LogIn
                    </NavLink>
                }
                <li>
                    <ThemeToggle/>
                </li>
            </ul>
            <button onClick={openMobileNav} className={styles.burger}><RxHamburgerMenu/></button>
            <dialog className={styles.dialog}
                    ref={navDialog}>
                <ul className={styles.mobileList}>
                    <Link to={"/"}><h3 className={styles.navLogo}>Blog Page</h3></Link>

                    <NavLink to='/'
                             onClick={closeMobileNav}
                             className={({isActive}) =>
                                 `${styles.navItem} 
                             ${isActive ? styles.activeLink : ''}`}>
                        Blog
                    </NavLink>
                    <NavLink to='projects'
                             onClick={closeMobileNav}
                             className={({isActive}) =>
                                 `${styles.navItem} 
                             ${isActive ? styles.activeLink : ''}`}>
                        Projects
                    </NavLink>
                    <NavLink to='about'
                             onClick={closeMobileNav}
                             className={({isActive}) =>
                                 `${styles.navItem} 
                             ${isActive ? styles.activeLink : ''}`}>
                        About
                    </NavLink>
                    <NavLink to='newsletter'
                             onClick={closeMobileNav}
                             className={({isActive}) =>
                                 `${styles.navItem} 
                             ${isActive ? styles.activeLink : ''}`}>
                        Newsletter
                    </NavLink>
                    <ThemeToggle/>
                    <button onClick={closeMobileNav} className={styles.closeBtn}>
                        <IoMdClose/>
                    </button>
                </ul>
            </dialog>
        </nav>
    );
};

