import axios, {AxiosInstance} from "axios";

const BASE_URL = 'http://localhost:5048/api';

const axiosInstance: AxiosInstance = axios.create({
    baseURL: BASE_URL,
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
    }
});
export default axiosInstance;
