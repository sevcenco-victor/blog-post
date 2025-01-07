import {useState} from "react";
import {Link} from "react-router-dom";
import TextInput from "../Inputs/TextInput";
import Button from "../Button";
import styles from './NewsletterSubscription.module.scss';


const NewsletterSubscription = () => {
    const [userEmail, setUserEmail] = useState("");

    const handleOnClick = () => {
        console.log(`User with email ${userEmail} subscribed`);
    }

    return (
        <div className={styles['subscription']}>
            <p className={`badge ${styles['subscription__badge']}`}>Newsletter</p>
            <h2 className={`${styles['subscription__header']}`}>Stories and interviews</h2>
            <p className={`${styles['subscription__description']}`}>Subscribe to learn about new product features, the
                latest in technology, solutions, and updates.</p>
            <div className={styles['subscription__form']}>
                <TextInput name={'userEmail'} onChange={(e) => setUserEmail(e.target.value)}
                           placeholder={'Enter your email'}/>
                <Button text={'Subscribe'} onClick={handleOnClick}/>
                <p>We care about your data in our <Link to="/privacy-policy">privacy policy</Link></p>
            </div>
        </div>
    );
};

export default NewsletterSubscription;