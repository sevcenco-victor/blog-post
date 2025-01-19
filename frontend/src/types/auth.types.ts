import {User} from "@/types/user.types.ts";

export type AuthContextType = {
    user: User | null;
    login: (formData: LoginForm) => void;
    logout: () => void;
    register: (formData: RegisterForm) => void;
}
export type RegisterForm = {
    username: string;
    email: string;
    password: string;
}
export type LoginForm = Omit<RegisterForm, 'username'>;
