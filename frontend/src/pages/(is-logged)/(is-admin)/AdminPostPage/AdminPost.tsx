import {ChangeEvent, FormEvent, FormEventHandler, SyntheticEvent, useEffect, useState} from 'react';
import {TabContext, TabList, TabPanel} from '@mui/lab'
import {Tab} from '@mui/material';
import MDEditor from '@uiw/react-md-editor';
import {mockPosts} from "../../../../mock/mockPosts";
import FormLabel from '../../../../components/Form/FormLabel';
import TextInput from "../../../../components/Inputs/TextInput";
import Button from "../../../../components/Button";
import PostCard from "../../../../components/Cards/PostCard";
import styles from './AdminPost.module.scss'

const AddPost = () => {
    const [content, setContent] = useState("your blog body goes here");

    const [form, setForm] = useState({
        title: '',
        text: '',
        imageUrl: '',
        markdownFileContent: ''
    })

    const handleFormChange = (e: ChangeEvent<HTMLInputElement>) => {
        const {name, value} = e.target;

        setForm(prevState => ({
            ...prevState,
            [name]: value
        }));
    }

    const handleFormSubmit = (e: FormEvent<FormEventHandler>) => {
        e.preventDefault();
        console.log('Submit add form', form)
    }
    return (
        <form method='POST' className={styles['form-add']}>
            <FormLabel text={'Title'}>
                <TextInput name={'title'} onChange={handleFormChange}
                           placeholder={'ex: this is the post title'}/>
            </FormLabel>
            <FormLabel text={'Text'}>
                <TextInput name={'text'} onChange={handleFormChange}
                           placeholder={'ex: this is the post short introduction text'}/>
            </FormLabel>
            <FormLabel text={'Image URL'}>
                <TextInput name={'imageUrl'} onChange={handleFormChange}
                           placeholder={'Thumbnail of the post ex: https://dog-with-hat.jpg'}/>
            </FormLabel>

            <MDEditor value={content}
                      onChange={setContent}
            />

            <Button text={'Add Post'} type={'submit'} onClick={() => {
            }}/>
        </form>
    )
}
const GetPosts = () => {
    const [search, setSearch] = useState('');

    const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value);
    }
    useEffect(() => {
        const handler = setTimeout(() => {
            console.log("seaching for: ", search)
        }, 1000);

        return () => {
            clearTimeout(handler);
        }
    }, [search])

    return (
        <div className={styles['get-posts']}>
            <FormLabel text={'Search'}>
                <TextInput name={'search'} onChange={handleSearchChange} placeholder={'Search post by title'}/>
            </FormLabel>
            <div className={styles['get-posts__wrapper']}>
                {mockPosts.slice(0, 3).map((post, index) =>
                    <PostCard
                        key={index}
                        id={index}
                        postDate={post.postDate}
                        title={post.title}
                        text={post.text}
                        imageUrl={post.imageUrl}
                        tags={post.tagList}
                        orientation={'portrait'}
                    />)}
            </div>
        </div>
    );
}

const AdminPost = () => {
    const [value, setValue] = useState('1');
    const handleChange = (newValue: string) => {
        setValue(newValue);
    }

    return (
        <div>
            <TabContext value={value}>
                <TabList onChange={(_: SyntheticEvent, v: string) => handleChange(v)} aria-label='lab API tabs example'>
                    <Tab label='Add' value='1'/>
                    <Tab label='Get' value='2'/>
                    <Tab label='Update' value='3'/>
                    <Tab label='Delete' value='4'/>
                </TabList>
                <TabPanel value='1'>{AddPost()}</TabPanel>
                <TabPanel value='2'>{GetPosts()}</TabPanel>
                <TabPanel value='3'>Update</TabPanel>
                <TabPanel value='4'>Delete</TabPanel>
            </TabContext>
        </div>
    );
};

export default AdminPost;