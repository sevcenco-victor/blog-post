import {ReactNode} from "react";
import styles from "./FormLabel.module.scss";

type FormProps = {
    text: string;
    children?: ReactNode;
}
export const FormLabel = ({text, children}: FormProps) => {
    return (
        <label className={styles.formLabel}>
            <p>{text}</p>
            {children}
        </label>
    );
};

export default FormLabel;