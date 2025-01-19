import {ChangeEvent, FormEvent, useState} from "react";
import {Link, useNavigate} from "react-router-dom";
import {useLocation} from "react-router";
import {Button, Input} from "@components";
import {FormLabel} from "@components/Form";
import {useAuth} from "@/hooks/useAuth.tsx";
import styles from './Login.module.scss';

export const Login = () => {
    const {login} = useAuth();
    const location = useLocation();
    const navigate = useNavigate();

    const [form, setForm] = useState({
        email: "",
        password: "",
    });
    const [error, setError] = useState<string | null>(null);

    const from = location.state?.from?.pathname || '/';

    const handleOnChange = (e: ChangeEvent<HTMLInputElement>) => {
        const {name, value} = e.target;

        setForm(prevState => ({
            ...prevState,
            [name]: value
        }));
    }
    const handleFormSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        setError(null);

        if (form.email === "" || form.password === "") {
            setError("Please complete both fields");
            return;
        }

        try {
            await login(form);
            navigate(from, {replace: true});
        } catch (error) {
            setError(error.message);
        }
    }
    const handleGoogleOption = () => {
        console.log("Google Authentication");
    }
    const handleFacebookOption = () => {
        console.log("Facebook Authentication");
    }
    return (
        <div className={styles.signIn}>
            <div className={styles.content}>
                <div className={styles.header}>
                    <h2>Welcome Back</h2>
                    <p>Today is a new day. It's your day. You shape it.
                        <br/>Sing in to start managing your projects.</p>
                    {error && (<p className={'error'}>{error}</p>)}
                </div>

                <form onSubmit={handleFormSubmit} className={styles.form}>
                    <FormLabel text={"Email"}>
                        <Input name="email" placeholder={'example@gmail.com'}
                               type={'email'}
                               autoComplete={"email"}
                               onChange={handleOnChange}/>
                    </FormLabel>
                    <FormLabel text={"Password"}>
                        <Input name="password" type={'password'} placeholder={'super strong pass'}
                               autoComplete="current-password" onChange={handleOnChange}/>
                    </FormLabel>
                    <Link to={"/forgot-password"} className={styles.forgotPassword}>Forgot Password?</Link>
                    <Button type="submit" text={"Sign in"}/>
                </form>

                <div className={styles.signInOptionsWrapper}>
                    <div className={styles.divider}>
                        <hr/>
                        <p>Or</p>
                        <hr/>
                    </div>
                    <Button text={"Google"} onClick={handleGoogleOption}/>
                    <Button text={"Facebook"} onClick={handleFacebookOption}/>
                </div>
                <p className={styles.signUpCall}>Don't you have an account? <Link to={'/register'}>Sign Up</Link></p>
            </div>
            <img
                className={styles.image}
                src="/login.jpg"
                alt="login-photo"
                loading="lazy"/>
        </div>

    );
};

export default Login;