import styles from './PrimaryButton.module.scss';

const PrimaryButton = ({onClick, text}) => {
    return (
        <button className={styles['button']} onClick={onClick}>
            {text}
        </button>
    );
};

export default PrimaryButton;