import {useEffect, useState} from "react";
import axiosInstance from "../apis/axiosInstance";
import {AxiosError} from "axios";

type configObj = {
    axiosInstance: typeof axiosInstance;
    method: "get" | "post" | "put" | "delete";
    url: string;
    requestConfig?: Record<string, any>;
}

const useAxios = <T, >({axiosInstance, method, url, requestConfig}: configObj) => {
    const [response, setResponse] = useState<T | undefined>(undefined);
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(true);
    const [reload, setReload] = useState(false);

    const refetch = () => setReload(!reload);

    useEffect(() => {
        const controller = new AbortController();

        const fetchData = async () => {
            try {
                const res = await axiosInstance[method](
                    url,
                    {
                        ...requestConfig,
                        signal: controller.signal,
                    });
                setResponse(res.data);
            } catch (err) {
                if (err instanceof AxiosError) {
                    if (err.name === "CanceledError") {
                        console.log("Request canceled");
                    } else {
                        console.log(err.message);
                        setError(err.message);
                    }
                } else {
                    console.log("Unexpected error:", err);
                    setError("An unexpected error occurred.");
                }
            } finally {
                setLoading(false);
            }
        }

        fetchData();

        return () => controller.abort();
    }, [reload]);

    return {response, error, loading, refetch};
}
export default useAxios;