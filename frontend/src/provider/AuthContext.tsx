import {createContext, PropsWithChildren, useState} from "react";
import axiosInstance, {setAxiosLogout} from "@/apis/axiosInstance.ts";
import {decodeJwt} from "@/utils/decodeJwt.ts";
import {User, AuthContextType, LoginForm, RegisterForm} from "@/types";
import {useNavigate} from "react-router-dom";


export const AuthContext = createContext<AuthContextType | null>(null);

export const AuthProvider = ({children}: PropsWithChildren) => {
    const [user, setUser] = useState<User | null>(decodeJwt(localStorage.getItem('token') || ''));
    const navigate = useNavigate();

    const login = async (formData: LoginForm) => {
        try {
            const res = await axiosInstance.post('/auth/login', formData);

            if (res.status === 200) {
                localStorage.setItem("token", res.data);
                setUser(decodeJwt(res.data));
            }
        } catch (error: any) {
            if (error.response) {
                throw new Error(error.response.data.message || "Invalid email or password");
            } else {
                throw new Error("An unexpected error occurred");
            }
        }
    }

    const register = async (formData: RegisterForm) => {
        try {
            await axiosInstance.post('/auth/register', formData);
        } catch (error: any) {
            if (error.response) {
                throw new Error(error.response.data.message);
            } else {
                throw new Error("An unexpected error occurred");
            }
        }
    }

    const logout = () => {
        localStorage.removeItem("token");
        setUser(null);
        navigate('/', {replace: true});
    }

    setAxiosLogout(logout);

    return <AuthContext.Provider value={{user, login, logout, register}}>
        {children}
    </AuthContext.Provider>
}

