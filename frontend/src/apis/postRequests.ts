import axiosInstance from "./axiosInstance.ts";
import {CreatePostRequest, DetailedPost, GetPaginatedPostRequest, Post} from "@/types";


export const getPosts = async ({pageNumber = 1, postNum, title, tagIds}
                               : GetPaginatedPostRequest): Promise<Post[]> => {
    const response = await axiosInstance.get<Post[]>(`/post/paginated`, {
        params: {pageSize: postNum, pageNumber: pageNumber, title: title, tagIds: {...tagIds}},
    });
    return response.data;
}
export const getUserPosts = async ({userId, pageNumber = 1, postNum, title, tagIds}
                                   : GetPaginatedPostRequest): Promise<Post[]> => {
    const response = await axiosInstance.get<Post[]>(`/post/user/${userId}`, {
        params: {pageSize: postNum, pageNumber: pageNumber, title: title, tagIds: {...tagIds}},
    });
    return response.data;
}

export const getPostById = async (id: string): Promise<DetailedPost> => {
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

export const addPost = async (body: CreatePostRequest): Promise<number> => {
    const response = await axiosInstance.post('/post', body);
    return response.data;
}
export const updatePost = async (id: number, body: CreatePostRequest): Promise<void> => {
    await axiosInstance.put(`/post/${id}`, body);
}
export const deletePost = async (id: number): Promise<void> => {
    await axiosInstance.delete(`/post/${id}`);
}
export const addPostTags = async (id: number, tagIds: number[]): Promise<void> => {
    await axiosInstance.patch(`/post/set-tags/${id}`, tagIds);
}