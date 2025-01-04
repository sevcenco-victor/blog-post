import styles from './PrimaryButton.module.scss';
import PropTypes from "prop-types";

const PrimaryButton = ({onClick, text}) => {
    return (
        <button className={styles['button']} onClick={onClick}>
            {text}
        </button>
    );
};

PrimaryButton.propTypes = {
    onClick: PropTypes.func,
    text: PropTypes.string,
}
export default PrimaryButton;