import axiosInstance from "./axiosInstance.ts";
import {TagTypes} from "@/types";

export const addTag = async (tag: TagTypes) : Promise<number>=> {
    const response = await axiosInstance.post(`/tag`, tag);
    return response.data;
}
export const getTags = async (): Promise<TagTypes[]> => {
    const response = await axiosInstance.get<TagTypes[]>('/tag');
    return response.data;
}
export const getTagById = async (id: number): Promise<TagTypes> => {
    const response = await axiosInstance.get<TagTypes>(`/tag/${id}`);
    return response.data;
}
export const updateTag = async (id: number, tag: TagTypes): Promise<void> => {
    const response = await axiosInstance.put(`/tag/${id}`, tag);
    return response.data;
}
export const deleteTag = async (id: number): Promise<void> => {
    const response = await axiosInstance.delete(`/tag/${id}`);
    return response.data;
}
