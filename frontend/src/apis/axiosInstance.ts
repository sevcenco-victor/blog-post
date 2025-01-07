import axios, {AxiosError} from "axios";
import {BASE_URL} from "../lib/constants.ts";

const axiosInstance = axios.create({
    baseURL: BASE_URL,
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
    }
});

axiosInstance.interceptors.response.use(
    (response) => response,
    (error: AxiosError) => {
        console.error(error);
        return Promise.reject(error.message);
    },
);

// axiosInstance.interceptors.request.use(
//     (config) => {
//     },
//     (error) => {
//     }
// );


export default axiosInstance;
