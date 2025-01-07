import axiosInstance from "./axiosInstance.ts";
import {Tag} from "../types";

export const addTag = async (tag: Tag) => {
    const response = await axiosInstance.post(`/tag`, tag);
    return response.data;
}
export const getTags = async () => {
    const response = await axiosInstance.get<Tag[]>('/tag');
    return response.data;
}
export const getTatById = async (id: number) => {
    const response = await axiosInstance.get<Tag>(`/tag/${id}`);
    return response.data;
}
export const updateTag = async (id: number, tag: Tag) => {
    const response = await axiosInstance.put(`/tag/${id}`, tag);
    return response.data;
}
export const deleteTag = async (id: number) => {
    const response = await axiosInstance.delete(`/tag/${id}`);
    return response.data;
}
