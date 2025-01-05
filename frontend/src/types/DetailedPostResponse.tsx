import {PostResponse} from "./PostResponse";

export  type DetailedPostResponse = PostResponse & {
    markDownFileLink: string;
}