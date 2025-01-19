import {ChangeEvent, useState} from "react";
import {useAxios} from "@/hooks/useAxios.tsx";
import {deletePost} from "@/apis/postRequests.ts";
import {Loader, Button,Input} from "@components";
import {FormLabel} from "@components/Form";

export const DeletePostForm = () => {
    const {data, isLoading, error, execute} = useAxios<void, number>(deletePost);
    const [postId, setPostId] = useState(-1);


    const handleInputChange = (e: ChangeEvent<HTMLInputElement>): void => {
        const {value} = e.target;
        setPostId(Number(value));
    }
    const handlePostDelete = (): void => {
        execute(postId).then();
    }

    if (isLoading) {
        return <Loader/>
    }
    return (
        <div>
            {error ? <p className={'error'}>Error: {error}</p> : ''}
            {data != undefined ? <p className={'success'}>Post deleted successfully!</p> : ''}
            <FormLabel text={'Post id'}>
                <Input name={'postId'} onChange={handleInputChange} placeholder={"ex: 1"}/>
            </FormLabel>
            <Button text={'Delete Post'} onClick={handlePostDelete}/>
        </div>
    )
}

export default DeletePostForm;