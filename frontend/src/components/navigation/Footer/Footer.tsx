import {Link} from "react-router-dom";
import styles from "./Footer.module.scss"

export const Footer = () => {
    return (
        <footer className={styles.footer}>
            <ul className={styles.list}>
                <li className={styles.listItem}>
                    © 2025
                </li>
                <li className={styles.listItem}>
                    <Link to={'#'}>Twitter</Link>
                </li>
                <li className={styles.listItem}>
                    <Link to={'#'}>LinkedIn</Link>
                </li>
                <li className={styles.listItem}>
                    <Link to={'#'}>Email</Link>
                </li>
                <li className={styles.listItem}>
                    <Link to={'#'}>RSS feed</Link>
                </li>
                <li className={styles.listItem}>
                    <Link to={'#'}>Add to Feedly</Link>
                </li>
            </ul>
        </footer>
    );
};
