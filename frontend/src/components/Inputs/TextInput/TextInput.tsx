import {ChangeEventHandler, ComponentPropsWithoutRef} from "react";
import styles from './TextInput.module.scss';

type InputProps = ComponentPropsWithoutRef<'input'> & {
    name: string;
    onChange: ChangeEventHandler<HTMLInputElement>;
}

const TextInput = ({name, onChange, ...rest}: InputProps) => {
    return (
        <input type={"text"}
               name={name}
               onChange={onChange}
               className={styles['input']}
               {...rest}
        />
    );
};

export default TextInput;