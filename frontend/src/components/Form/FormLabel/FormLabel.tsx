import PropTypes from "prop-types";
import styles from "./FormLabel.module.scss";
import {ReactNode} from "react";

type FormProps = {
    text: string;
    children?: ReactNode;
}
const FormLabel = ({text, children}: FormProps) => {
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