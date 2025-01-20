import {useState} from "react";
import {Link, useNavigate} from "react-router-dom";
import {useForm} from "react-hook-form";
import {z} from 'zod';
import {Button} from "@components";
import {Form, FormLabel} from "@components/Form";
import {useAuth} from "@/hooks/useAuth.tsx";
import {zodResolver} from "@hookform/resolvers/zod";
import styles from "@/pages/Login/Login.module.scss";

const formSchema = z.object({
    username: z.string().min(5, "Username must be at least 5 characters"),
    email: z.string().email(),
    password: z.string().min(8, "Password must be at least 8 characters"),
})

type FormFields = z.infer<typeof formSchema>;

export const Register = () => {
    const {register: registerUser} = useAuth();
    const navigate = useNavigate();
    const {
        register,
        handleSubmit,
        formState: {errors, isSubmitting},
    } = useForm<FormFields>(
        {
            resolver: zodResolver(formSchema)
        }
    )
    const [error, setError] = useState<string | null>(null);

    const onSubmit = async (data: FormFields) => {
        try {
            await registerUser(data);
            navigate("/login");
        } catch (error) {
            console.log(error);

            let composedError = "";
            error.response.data.errors.map(er => composedError += er.description)

            setError(composedError);
        }
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

                <Form onSubmit={handleSubmit(onSubmit)} className={styles.form}>
                    <FormLabel text={"Username"}>
                        <input
                            {...register('username')}
                            placeholder={'user123'}
                            type={'text'}
                            autoComplete={"username"}/>
                        {errors.username && (<span className={'input-error'}>{errors.username.message}</span>)}
                    </FormLabel>
                    <FormLabel text={"Email"}>
                        <input
                            {...register("email")}
                            placeholder={'example@gmail.com'}
                            type={'email'}
                            autoComplete={"email"}/>
                        {errors.email && (<span className={'input-error'}>{errors.email.message}</span>)}

                    </FormLabel>
                    <FormLabel text={"Password"}>
                        <input {...register("password")}
                               type={'password'}
                               placeholder={'super strong pass'}
                               autoComplete="current-password"/>
                        {errors.password && (<span className={'input-error'}>{errors.password.message}</span>)}

                    </FormLabel>
                    <Button type="submit" disabled={isSubmitting} text={isSubmitting ? "Loading..." : "Sign in"}/>
                </Form>
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