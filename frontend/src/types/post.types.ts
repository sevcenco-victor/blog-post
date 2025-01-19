import {TagTypes} from "@/types";

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
    userId: string;
    tagIds: number[];
    markdownFileContent: string;
}

export type DetailedPost = Post & {
    markDownFileLink: string;
    authorUsername: string;
}

export type CreatePostRequest = Pick<Post, 'title' | 'text' | 'imageUrl'> & {
    userId: string,
    markdownFileContent: string,
    tagIds: number[]
}

export type GetPaginatedPostRequest = {
    userId?: string;
    pageNumber?: number;
    postNum: number;
    title?: string;
    tagIds?: number [];
}