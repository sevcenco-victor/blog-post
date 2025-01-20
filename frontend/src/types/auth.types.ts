import {User} from "@/types/user.types.ts";
import {z} from "zod";

export type AuthContextType = {
    user: User | null;
    login: (formData: LogInForm) => void;
    logout: () => void;
    register: (formData: RegisterForm) => void;
}
export type RegisterForm = {
    username: string;
    email: string;
    password: string;
}
export type LogInForm = Omit<RegisterForm, 'username'>;

export const LogInSchema = z.object({
    email: z.string().email(),
    password: z.string().min(6)
});

export type LogInFields = z.infer<typeof LogInSchema>;