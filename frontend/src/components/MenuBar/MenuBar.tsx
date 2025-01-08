import {MenuBarProps} from "@/types";
import styles from './MenuBar.module.scss';

export const MenuBar = ({children}: MenuBarProps) => {
    return (
        <nav className={styles.menuBar}>
            {children}
        </nav>
    );
};

export default MenuBar;