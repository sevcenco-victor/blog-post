import {Tag} from "./Tag";

export type PostResponse = {
    id: number;
    title: string;
    text: string;
    imageUrl: string;
    postDate: string;
    tagList: Tag[];
}