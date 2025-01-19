import {FormProps} from "@/types";
import styles from "./Form.module.scss";

export const Form = ({children, ...rest}: FormProps) => {
    return (
        <form className={styles.form} {...rest}>
            {children}
        </form>
    );
};

export default Form;