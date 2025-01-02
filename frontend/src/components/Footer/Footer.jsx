import styles from "./Footer.module.scss"
import {Link} from "react-router-dom";

const Footer = () => {
    return (
        <footer className={styles['footer']}>
            <ul className={styles['footer__list']}>
                <li className={styles['footer__list-item']}>
                    <Link to={'#'}>© 2025</Link>
                </li>
                <li className={styles['footer__list-item']}>
                    <Link to={'#'}>Twitter</Link>
                </li>
                <li className={styles['footer__list-item']}>
                    <Link to={'#'}>LinkedIn</Link>
                </li>
                <li className={styles['footer__list-item']}>
                    <Link to={'#'}>Email</Link>
                </li>
                <li className={styles['footer__list-item']}>
                    <Link to={'#'}>RSS feed</Link>
                </li>
                <li className={styles['footer__list-item']}>
                    <Link to={'#'}>Add to Feedly</Link>
                </li>
            </ul>
        </footer>
    );
};

export default Footer;