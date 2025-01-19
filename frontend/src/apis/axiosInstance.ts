import axios from "axios";
import {BASE_URL} from "../lib/constants.ts";

const axiosInstance = axios.create({
    baseURL: BASE_URL,
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
    },
    withCredentials: true,
});

let logoutFunction: (() => void) | null = null;
export const setAxiosLogout = (logout: () => void) => {
    logoutFunction = logout;
}

axiosInstance.interceptors.response.use(
    (response) => response,

    async (error) => {
        const originalRequest = {...error.config};
        originalRequest._isRetry = true;
        if (error.response.status === 401
            && error.config
            && !error.config._isRetry
        ) {
            try {
                const accessToken = localStorage.getItem("token");
                const res = await axiosInstance.post('/auth/refreshToken', {accessToken: accessToken});
                localStorage.setItem("token", res.data);
                return axiosInstance.request(originalRequest);
            } catch (error) {
                if (logoutFunction) {
                    logoutFunction();
                }
            }
        }
        throw error;
    }
);

axiosInstance.interceptors.request.use(
    (config) => {
        config.headers['Authorization'] = `Bearer ${localStorage.getItem("token")}`;
        return config;
    },
    (error) => Promise.reject(error),
);


export default axiosInstance;
