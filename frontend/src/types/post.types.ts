import {TagTypes} from "./tag.types.ts";

export type Post = {
    id: number;
    title: string;
    text: string;
    imageUrl: string;
    postDate: string;
    lastEdit: string;
    tags: TagTypes[];
}

export type AddPostRequestPayload = Omit<Post, "id" | "postDate" | "lastEdit" | "tags"> & {
    tagIds: number[];
    markdownFileContent: string;
}

export type DetailedPost = Post & {
    markDownFileLink: string;
}