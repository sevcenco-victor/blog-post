import {Link, useNavigate} from "react-router-dom";
import {useLocation} from "react-router";
import {useForm} from "react-hook-form";
import {Button} from "@components";
import {FormLabel} from "@components/Form";
import {useAuth} from "@/hooks/useAuth.tsx";
import {zodResolver} from "@hookform/resolvers/zod";
import {LogInFields, LogInSchema} from "@/types";
import styles from './Login.module.scss';


export const Login = () => {
    const {login} = useAuth();
    const {
        register,
        handleSubmit,
        setError,
        formState: {errors, isSubmitting}
    } = useForm<LogInFields>({
        resolver: zodResolver(LogInSchema),
    });

    const location = useLocation();
    const navigate = useNavigate();

    const from = location.state?.from?.pathname || '/';

    const onSubmit = async (data: LogInFields) => {
        try {
            await login(data);
            navigate(from, {replace: true});
        } catch (error) {
            setError("root", {message: error.message});
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
                    {errors.root && (<p className={'input-error'}>{errors.root.message}</p>)}
                </div>

                <form onSubmit={handleSubmit(onSubmit)} className={styles.form}>
                    <FormLabel text={"Email"}>
                        <input  {...register("email",)}
                                placeholder={'example@gmail.com'}
                                type={'email'}
                                autoComplete={"email"}/>
                        {errors.email && <span className={'input-error'}>{errors.email.message}</span>}
                    </FormLabel>
                    <FormLabel text={"Password"}>
                        <input type="password"
                               {...register("password")}
                               placeholder={'password'}
                               autoComplete="current-password"
                        />
                        {errors.password && <span className={'input-error'}>{errors.password.message}</span>}
                    </FormLabel>
                    <Link to={"/forgot-password"} className={styles.forgotPassword}>Forgot Password?</Link>
                    <Button type="submit" disabled={isSubmitting}
                            text={isSubmitting ? "Loading..." : "Log In"}/>
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