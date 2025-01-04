import PropTypes from "prop-types";
import styles from "./FormLabel.module.scss";

const FormLabel = ({text = "label", children}) => {
    return (
        <label className={styles['form-label']}>
            <p>{text}</p>
            {children}
        </label>
    );
};

FormLabel.propTypes = {
    text: PropTypes.string.isRequired,
    children: PropTypes.element.isRequired,
}

export default FormLabel;