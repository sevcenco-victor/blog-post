import styles from './PostPage.module.css'
import React from "react";
import PostCard from "src/components/Cards/PostCard/PostCard.jsx";
import {useParams} from "react-router";

const tagList = [
    {name: "Design", color: "#C11574"},
    {name: "Development", color: "#007ACC"},
    {name: "Marketing", color: "#F7931A"},
    {name: "Finance", color: "#2ECC71"},
    {name: "HR", color: "#9B59B6"}
];

const postCards = [
    {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    },

]

const PostPage = () => {
    const {postId} = useParams();

    return (
        <div className={`page ${styles['post-page']}`}>
            <section className={`section ${styles['section-recent-posts']}}`}>
                <h2 className={`section__header`}>Project List</h2>
                <div className={`section__body ${styles['section-recent-posts__content']}`}>
                    {
                        postCards.map((p, index) => <PostCard id={p.id} key={index}
                                                              imageUrl={p.imageUrl}
                                                              postDate={p.postDate}
                                                              title={p.title}
                                                              text={p.text}
                                                              tagList={p.tagList}
                                                              orientation={p.orientation}
                        />)
                    }
                </div>
            </section>
            <section className={`section ${styles['section-post-details']}`}>
                <p className={'badge'}>post Date</p>
                <h2>Grid system for better Design User Interface</h2>
                <img src="https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg" alt="active-post-photo"/>
            </section>
        </div>
    );
};

export default PostPage;