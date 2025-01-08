import axiosInstance from "./axiosInstance.ts";
import {DetailedPost, Post} from "@/types";

type PostRequest = {
    title: string,
    text: string,
    imageUrl: string,
    markdownFileContent: string,
    tagIds: number[]
}

export const getPosts = async (pageNum = 1, pageSize = 10): Promise<Post[]> => {
    const response = await axiosInstance.get<Post[]>(`/post/paginated`, {
        params: {pageSize: pageSize, pageNumber: pageNum},
    });
    return response.data;
}
export const getPostById = async (id: number): Promise<DetailedPost> => {
    const response = await axiosInstance.get<DetailedPost>(`/post/${id}`);
    return response.data;
}
export const getLatestPosts = async (num: number): Promise<Post[]> => {
    const response = await axiosInstance.get<Post[]>(`/Post/latest`, {
        params: {num: num}
    });
    return response.data;
}
export const getPostsQuantity = async (): Promise<number> => {
    const response = await axiosInstance.get(`/post/qty`);
    return response.data;
}

export const addPost = async (body: PostRequest): Promise<number> => {
    const response = await axiosInstance.post('/post', body);
    return response.data;
}
export const updatePost = async (id: number, body: PostRequest): Promise<void> => {
    await axiosInstance.put(`/post/${id}`, body);
}
export const deletePost = async (id: number): Promise<void> => {
    await axiosInstance.delete(`/post/${id}`);
}
export const addPostTags = async (id: number, tagIds: number[]): Promise<void> => {
    await axiosInstance.patch(`/post/set-tags/${id}`, tagIds);
}