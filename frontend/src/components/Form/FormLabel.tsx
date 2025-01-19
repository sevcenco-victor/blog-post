import {FormLabelProps} from "@/types";
import styles from "./Form.module.scss";


export const FormLabel = ({text, children}: FormLabelProps) => {
    return (
        <label className={styles.formLabel}>
            <p>{text}</p>
            {children}
        </label>
    );
};

export default FormLabel;