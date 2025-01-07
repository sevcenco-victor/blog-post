import {ReactNode} from "react";
import styles from "./FormLabel.module.scss";

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

export default FormLabel;