import {ChangeEvent, FormEvent, useState} from "react";
import {Button} from "@components";
import {FormLabel, Form} from "@components/Form";
import {Input} from "@components/Input";
import styles from './Profile.module.scss';

export const Profile = () => {
    const [form, setForm] = useState({
        username: '',
        email: '',
    })
    const handleFormSubmit = (e: FormEvent) => {
        e.preventDefault();

        console.log("handleFormSubmit", form);
    }
    const handleOnChange = (e: ChangeEvent<HTMLInputElement>) => {
        const {name, value} = e.target;
        setForm(prevState => ({...prevState, [name]: value}));
    }
    return (
        <div>
            <h2>Profile</h2>
            <Form onSubmit={handleFormSubmit}>
                <FormLabel text={"Username"}>
                    <Input name="username" value={form.username} onChange={handleOnChange} autoComplete={"username"}/>
                </FormLabel>
                <FormLabel text={"Email"}>
                    <Input name="email" type={'email'} value={form.email} onChange={handleOnChange}
                           autoComplete={"email"}/>
                </FormLabel>
                <Button type="submit" text={"Save"}/>
            </Form>
        </div>
    );
};

export default Profile;