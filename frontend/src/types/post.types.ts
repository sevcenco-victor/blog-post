import {TagTypes} from "@/types";

export type Post = {
    id: number;
    title: string;
    subText: string;
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

export type CreatePostRequest = Pick<Post, 'title' | 'subText' | 'imageUrl'> & {
    userId: string,
    markdownFileContent: string,
    tagIds: string[]
}

export type GetPaginatedPostRequest = {
    userId?: string;
    pageNumber?: number;
    postNum: number;
    title?: string;
    tagIds?: number [];
}