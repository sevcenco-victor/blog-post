import styles from "@/pages/Login/Login.module.scss";
import {FormLabel} from "@components/Form";
import {Link, useNavigate} from "react-router-dom";
import {Button,Input} from "@components";
import {ChangeEvent, FormEvent, useState} from "react";
import {useAuth} from "@/hooks/useAuth.tsx";

export const Register = () => {
    const {register} = useAuth();
    const navigate = useNavigate();

    const [error, setError] = useState<string | null>(null);
    const [form, setForm] = useState({
        username: "",
        email: "",
        password: "",
    });


    const handleFormSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            await register(form);
            navigate("/login");
        } catch (error) {
            console.log(error);

            let composedError = "";
            error.response.data.errors.map(er => composedError += er.description)

            setError(composedError);
        }
    }
    const handleOnChange = (event: ChangeEvent<HTMLInputElement>) => {
        const {name, value} = event.target;
        setForm(prev => ({
            ...prev,
            [name]: value
        }));
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
                    <FormLabel text={"Username"}>
                        <Input name="username" placeholder={'example'}
                               type={'text'}
                               autoComplete={"username"}
                               onChange={handleOnChange}/>
                    </FormLabel>
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
                    <Button type="submit" text={"Sign in"}/>
                </form>
                <p className={styles.signUpCall}>Already have an account? <Link to={'/login'}>Log In</Link></p>
            </div>
            <img
                className={styles.image}
                src="/login.jpg"
                alt="login-photo"
                loading="lazy"/>
        </div>
    );
};

export default Register;