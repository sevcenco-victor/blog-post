import {ComponentPropsWithoutRef} from "react";
import styles from './PrimaryButton.module.scss';

type ButtonProps = ComponentPropsWithoutRef<'button'> & {
    variant?: "primary" | "secondary";
    text: string;
    onClick: () => void;
};

const Button = ({onClick, text, ...rest}: ButtonProps) => {
    return (
        <button className={styles['button']} onClick={onClick} {...rest}>
            {text}
        </button>
    );
};

export default Button;