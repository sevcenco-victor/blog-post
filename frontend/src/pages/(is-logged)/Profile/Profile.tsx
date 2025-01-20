import {useEffect} from "react";
import {useForm} from "react-hook-form";
import {z} from 'zod';
import {Button, Loader} from "@components";
import {FormLabel, Form} from "@components/Form";
import {useAxios} from "@/hooks/useAxios.tsx";
import {UserResponse} from "@/types";
import {getUserById} from "@/apis/userRequests.ts";
import {useAuth} from "@/hooks/useAuth.tsx";
import {zodResolver} from "@hookform/resolvers/zod";

const ProfileSchema = z.object({
    username: z.string().min(5, "Username must have at least 5 characters"),
    email: z.string().email(),
    birthday: z.string().date(),
});
type FormFields = z.infer<typeof ProfileSchema>;

export const Profile = () => {
    const {
        data,
        isLoading,
        error,
        execute: executeGetUserById,
    } = useAxios<UserResponse, string>(getUserById)
    const {user} = useAuth();
    const {
        register,
        setError,
        setValue,
        handleSubmit,
        formState: {errors, isSubmitting}
    } = useForm<FormFields>(
        {
            resolver: zodResolver(ProfileSchema),
        }
    )

    const onSubmit = (data: FormFields) => {

        console.log("onSubmit", data);
    }

    useEffect(() => {
        if (user) {
            executeGetUserById(user.id).then();
        }
    }, []);

    useEffect(() => {
        if (data !== null) {
            setValue("username", data.username);
            setValue("email", data.email);
            setValue("birthday", data.birthday);
        }
    }, [data]);

    if (isLoading) {
        return <Loader/>
    }
    if (error) {
        return <p className="error">{error}</p>
    }

    return (
        <div>
            <h2>Profile</h2>
            <Form onSubmit={handleSubmit(onSubmit)}>
                <FormLabel text={"Username"}>
                    <input
                        {...register("username")}
                        placeholder={"user_name33"}
                        autoComplete={"username"}/>
                    {errors.username && (<span className={'input-error'}>{errors.username.message}</span>)}
                </FormLabel>
                <FormLabel text={"Email"}>
                    <input
                        {...register("email")}
                        type={'email'}
                        placeholder={"example@gmail.com"}
                        autoComplete={"email"}/>
                    {errors.email && (<span className={'input-error'}>{errors.email.message}</span>)}
                </FormLabel>
                <FormLabel text={"Birth Date"}>
                    <input
                        {...register('birthday')}
                        type={'date'}/>
                    {errors.birthday && (<span className={'input-error'}>{errors.birthday.message}</span>)}
                </FormLabel>
                <Button type="submit"
                        disabled={isSubmitting}
                        text={isSubmitting ? "Loading..." : "Submit"}/>
            </Form>
        </div>
    );
};

export default Profile;