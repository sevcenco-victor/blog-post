import {MenuBarGroupProps} from "@/types";
import styles from "./MenuBar.module.scss";

export const MenuBarGroup = ({groupName, children}: MenuBarGroupProps) => {
    return (
        <div className={styles.group}>
            <p className={styles.header}>{groupName}</p>
            <ul className={styles.list}>
                {children}
            </ul>
        </div>
    );
}

export default MenuBarGroup;