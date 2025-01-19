import {useCallback, useState} from "react";
import {useErrorBoundary} from "react-error-boundary";

type UseAxiosReturn<T, U> = {
    data: T | null;
    isLoading: boolean;
    error: string | null;
    execute: (...args: U[]) => Promise<void>;
}

export const useAxios = <T, U>(axiosFunction: (...args: U[]) => Promise<T>): UseAxiosReturn<T, U> => {
    {
        const [data, setData] = useState<T | null>(null);
        const [isLoading, setIsLoading] = useState<boolean>(false);
        const [error, setError] = useState<string | null>(null);
        const {showBoundary} = useErrorBoundary();

        const execute = useCallback(
            async (...args: U[]) => {
                setIsLoading(true);
                setError(null);
                try {
                    const result = await axiosFunction(...args);
                    setData(result);
                } catch (error) {
                    showBoundary(error);
                } finally {
                    setIsLoading(false);
                }
            }, [axiosFunction]);

        return {data, isLoading, error, execute};
    }

}