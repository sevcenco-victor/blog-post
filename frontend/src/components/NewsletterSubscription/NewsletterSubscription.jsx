import TextInput from "src/components/Inputs/TextInput/TextInput.jsx";
import PrimaryButton from "src/components/Buttons/PrimaryButton/PrimaryButton.jsx";
import styles from "src/pages/NewsletterPage/NewsletterPage.module.scss";

const NewsletterSubscription = ({}) => {
    const handleOnChange = (_) => {

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
                <TextInput onChange={handleOnChange} placeholder={'Enter your email'}/>
                <PrimaryButton text={'Subscribe'} onClick={handleOnClick}/>
                <p>We care about your data in our <a href="#">privacy policy</a></p>
            </div>
        </div>
    );
};

export default NewsletterSubscription;