import {UserResponse} from "@/types";
import axiosInstance from "@/apis/axiosInstance.ts";

export const getUserById = async (id: string): Promise<UserResponse> => {
    const result = await axiosInstance.get(`/user/${id}`);
    return result.data;
}