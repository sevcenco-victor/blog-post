import {InputProps} from "@/types";

export const Input = ({name, onChange, ...rest}: InputProps) => {
    return (
        <input type={"text"}
               name={name}
               onChange={onChange}
               {...rest}
        />
    );
};

export default Input;