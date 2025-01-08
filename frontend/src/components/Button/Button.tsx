import {ComponentPropsWithoutRef} from "react";
import styles from './Button.module.scss';

type ButtonProps = ComponentPropsWithoutRef<'button'> & {
    variant?: "primary" | "secondary";
    text: string;
    onClick?: () => void;
};

export const Button = ({onClick, text, ...rest}: ButtonProps) => {
    return (
        <button className={styles.button} onClick={onClick} {...rest}>
            {text}
        </button>
    );
};

export default Button;