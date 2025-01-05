import TextInput from "../Inputs/TextInput/TextInput";
import Button from "../Buttons/PrimaryButton/Button";
import styles from './NewsletterSubscription.module.scss';


const NewsletterSubscription = () => {
    const handleOnChange = (_: any) => {

    }
    const handleOnClick = () => {
        console.log("SUBSCRIBE")
    }

    return (
        <div className={styles['section-cta']}>
            <p className={`badge`}>Newsletter</p>
            <h2>Stories and interviews</h2>
            <p>Subscribe to learn about new product features, the latest in technology, solutions, and updates.</p>
            <div className={styles['section-cta__form']}>
                <TextInput name={'userEmail'} onChange={handleOnChange} placeholder={'Enter your email'}/>
                <Button text={'Subscribe'} onClick={handleOnClick}/>
                <p>We care about your data in our <a href="#">privacy policy</a></p>
            </div>
        </div>
    );
};

export default NewsletterSubscription;