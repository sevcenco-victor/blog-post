import styles from './TextInput.module.scss';
import propTypes from 'prop-types'

const TextInput = ({name, placeholder, onChange}) => {
    return (
        <input type={"text"}
               name={name}
               onChange={onChange}
               className={styles['input']}
               placeholder={placeholder}/>
    );
};

TextInput.propTypes = {
    name: propTypes.string.isRequired,
    placeholder: propTypes.string,
    onChange: propTypes.func.isRequired
}

export default TextInput;