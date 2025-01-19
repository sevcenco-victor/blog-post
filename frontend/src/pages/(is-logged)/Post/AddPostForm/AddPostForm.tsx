import {ChangeEvent, FormEvent, useEffect, useState} from "react";
import {Link} from "react-router-dom";
import MDEditor from "@uiw/react-md-editor";
import {useAxios} from "@/hooks/useAxios.tsx";
import {AddPostRequestPayload, TagTypes} from "@/types";
import {addPost} from "@/apis/postRequests.ts";
import {getTags} from "@/apis/tagRequests.ts";
import {Button, Loader, TagBadge, Input} from "@components";
import {Form, FormLabel} from "@components/Form";
import {useAuth} from "@/hooks/useAuth.tsx";
import styles from "./AddPostForm.module.scss";

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

    const [content, setContent] = useState("your blog body goes here");
    const [selectedTags, setSelectedTags] = useState<TagTypes[]>([]);

    const [form, setForm] = useState<AddPostRequestPayload>({
        title: '',
        text: '',
        imageUrl: '',
        tagIds: [],
        markdownFileContent: '',
        userId: '',
    })

    useEffect(() => {
        executeGetTags().then();
    }, [executeGetTags]);

    const handleFormChange = (e: ChangeEvent<HTMLInputElement>) => {
        const {name, value} = e.target;

        setForm(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const handleFormSubmit = async (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        form.userId = user!.id;
        const body = {...form, markdownFileContent: content, tagIds: selectedTags.map(t => t.id)};

        await executeAddPost(body);
        setForm({
            title: '',
            text: '',
            imageUrl: '',
            tagIds: [],
            markdownFileContent: '',
            userId: ''
        });
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

    const combinedError = [errorAddPost, errorGetTags]
        .filter(Boolean)
        .join(',');

    if (combinedError) {
        return <p className={'error'}>{combinedError}</p>
    }
    if (isLoadingAddPost) {
        return <Loader/>;
    }

    return (
        <>
            <Form onSubmit={handleFormSubmit}>
                {postId && <p style={{color: 'green'}}>Post added, <Link to={`/post/${postId}`}>view post</Link></p>}
                <FormLabel text={'Title'}>
                    <Input name={'title'} onChange={handleFormChange}
                           placeholder={'ex: this is the post title'}/>
                </FormLabel>
                <FormLabel text={'Text'}>
                    <Input name={'text'} onChange={handleFormChange}
                           placeholder={'ex: this is the post short introduction text'}/>
                </FormLabel>
                <FormLabel text={'Image URL'}>
                    <Input name={'imageUrl'} onChange={handleFormChange}
                           placeholder={'Thumbnail of the post ex: https://dog-with-hat.jpg'}/>
                </FormLabel>

                <MDEditor value={content}
                          onChange={(text) => setContent(text || "")}
                />
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
                <Button text={'Add Post'} type={'submit'} onClick={() => {
                }}/>
            </Form>
        </>

    )
}

export default AddPostForm;