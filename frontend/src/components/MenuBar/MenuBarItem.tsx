import {NavLink} from "react-router-dom";
import {MenuBarItemProps} from "@/types";
import styles from "./MenuBar.module.scss";

export const MenuBarItem = ({to, text, ...rest}: MenuBarItemProps) => {
    return (
        <NavLink to={to} className={({isActive}) =>
            `${styles.menuItem} 
            ${isActive ? styles.activeMenuItem : ''}`}
                 {...rest}>
            {text}
        </NavLink>
    );
};

export default MenuBarItem;