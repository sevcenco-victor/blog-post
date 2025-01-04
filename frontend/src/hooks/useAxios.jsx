import {useEffect, useState} from "react";

const useAxios = (configObj) => {
    const {
        axiosInstance,
        method,
        url,
        requestConfig = {}
    } = configObj;

    const [response, setResponse] = useState([]);
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(true);
    const [reload, setReload] = useState(false);

    const refetch = () => setReload(!reload);

    useEffect(() => {
        const controller = new AbortController();

        const fetchData = async () => {
            try {
                const res = await axiosInstance[method.toLowerCase()](
                    url,
                    {
                        ...requestConfig,
                        signal: controller.signal,
                    });
                setResponse(res.data);
            } catch (err) {
                if (err.name === "CanceledError") {
                    console.log("Request canceled");
                } else {
                    console.log(err.message);
                    setError(err.message);
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