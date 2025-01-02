    import styles from './TextInput.module.scss';

const TextInput = ({placeholder, onChange}) => {
    return (
        <input type={"text"}
               onChange={onChange}
               className={styles['input']}
               placeholder={placeholder}/>
    );
};

export default TextInput;