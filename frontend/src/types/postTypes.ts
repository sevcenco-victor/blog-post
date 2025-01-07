import {Tag} from "./tag.ts";

export interface Post {
    id: number;
    title: string;
    text: string;
    imageUrl: string;
    postDate: string;
    tags: Tag[];
}

export interface DetailedPost extends Post {
    markDownFileLink: string;
}