import {Outlet} from "react-router";
import {NavLink} from "react-router-dom";
import styles from "./AdminLayout.module.scss";

const AdminLayout = () => {
    return (
        <div className={styles['admin-layout']}>
            <nav className={styles['admin-nav']}>
                <div className={styles['admin-nav__element']}>
                    <p>ENTITIES</p>
                    <ul className={styles['admin-nav__list']}>
                        <NavLink to="post">Post</NavLink>
                        <NavLink to="tag">Tag</NavLink>
                    </ul>
                </div>
            </nav>
            <Outlet/>
        </div>
    );
};

export default AdminLayout;