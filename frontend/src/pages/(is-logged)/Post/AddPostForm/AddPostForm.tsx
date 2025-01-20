import {useEffect, useState} from "react";
import {useForm} from "react-hook-form";
import {Link} from "react-router-dom";
import {z} from 'zod';
import MDEditor from "@uiw/react-md-editor";
import {useAxios} from "@/hooks/useAxios.tsx";
import {AddPostRequestPayload, TagTypes} from "@/types";
import {addPost} from "@/apis/postRequests.ts";
import {getTags} from "@/apis/tagRequests.ts";
import {Button, Loader, TagBadge} from "@components";
import {Form, FormLabel} from "@components/Form";
import {useAuth} from "@/hooks/useAuth.tsx";
import styles from "./AddPostForm.module.scss";
import {zodResolver} from "@hookform/resolvers/zod";

const FormSchema = z.object({
    title: z.string().min(5, "Title must have at least 5 characters"),
    subText: z.string().min(5),
    imageUrl: z.string(),
});

type FormFields = z.infer<typeof FormSchema>;


export const AddPostForm = () => {
    const {user} = useAuth();
    const {
        data: postId,
        error: errorAddPost,
        isLoading: isLoadingAddPost,
        execute: executeAddPost
    } = useAxios<number, AddPostRequestPayload>(addPost);

    const {
        data: tags,
        error: errorGetTags,
        isLoading: isLoadingGetTags,
        execute: executeGetTags
    } = useAxios<TagTypes[], void>(getTags);
    const {
        register,
        handleSubmit,
        reset,
        getValues,
        formState: {errors, isSubmitting}
    } = useForm<FormFields>({
        resolver: zodResolver(FormSchema),
    })

    const [content, setContent] = useState("your blog body goes here");
    const [selectedTags, setSelectedTags] = useState<TagTypes[]>([]);


    useEffect(() => {
        executeGetTags().then();
    }, [executeGetTags]);


    const onSubmit = async (data: FormFields) => {
        console.log(data);

        if (!user) return;

        const reqBody = {
            ...getValues(),
            userId: user.id,
            markdownFileContent: content,
            tagIds: selectedTags.map(t => t.id)
        };

        console.log(reqBody);

        await executeAddPost(reqBody);

        reset();
    }

    const handleAddTag = (tag: TagTypes) => {
        setSelectedTags(prev => {
            if (!prev.some(t => t === tag)) {
                return [...prev, tag];
            }
            return prev;
        });
    }

    const handleRemoveTag = (tag: TagTypes) => {
        setSelectedTags(prev => prev.filter((t) => t !== tag));
    }

    if (isLoadingAddPost) {
        return <Loader/>;
    }

    return (
        <Form onSubmit={handleSubmit(onSubmit)}>
            {postId && <p style={{color: 'green'}}>Post added, <Link to={`/post/${postId}`}>view post</Link></p>}
            <FormLabel text={'Title'}>
                <input
                    {...register("title")}
                    placeholder={'ex: this is the post title'}/>
                {errors.title && (<span className={'input-error'}>{errors.title.message}</span>)}
            </FormLabel>
            <FormLabel text={'Subtext'}>
                <input
                    {...register("subText")}
                    placeholder={'ex: this is the post short introduction text'}/>
                {errors.subText && (<span className={'input-error'}>{errors.subText.message}</span>)}
            </FormLabel>
            <FormLabel text={'Image URL'}>
                <input
                    {...register("imageUrl")}
                    placeholder={'Thumbnail of the post ex: https://dog-with-hat.jpg'}/>
                {errors.imageUrl && (<span className={'input-error'}>{errors.imageUrl.message}</span>)}
            </FormLabel>

            <MDEditor value={content}
                      onChange={(text) => setContent(text || "")}/>

            <div className={styles.formTags}>
                <p>Selected tags:</p>
                <div className={styles.list}>
                    {selectedTags.map(t => <TagBadge key={`selected-tags-${t.id}`}
                                                     tag={{id: t.id, name: t.name + " x", color: t.color}}
                                                     onClick={() => handleRemoveTag(t)}/>)}
                </div>
            </div>
            <div className={styles.formTags}>
                <p>Available tags: </p>
                <div className={styles.list}>
                    {isLoadingGetTags
                        ? <Loader/>
                        : tags?.map(t => <TagBadge key={`add-post-tag-id${t.id}`}
                                                   tag={{id: t.id, name: t.name + " +", color: t.color}}
                                                   onClick={() => handleAddTag(t)}/>
                        )
                    }
                </div>
            </div>
            <Button type={'submit'} disabled={isSubmitting} onClick={() => console.log("CLIKC")}
                    text={isSubmitting ? 'Loading...' : 'Add Post'}/>
        </Form>
    )
}

export default AddPostForm;