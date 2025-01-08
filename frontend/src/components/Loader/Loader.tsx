import styles from "./Loader.module.scss";

export const Loader = () => {
    return (
        <div className={styles.loaderBg}>
            <div className={styles.loader}/>
        </div>
    );
};

export default Loader;