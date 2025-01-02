import React from 'react';
import styles from './ProjectPage.module.scss';
import PostCard from "src/components/Cards/PostCard/PostCard.jsx";

const ProjectPage = () => {
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


    return (
        <div className={`page ${styles['project-page']}`}>
            <section className={`section section-hero`}>
                <div className={`section-hero__title-wrapper`}>
                    <h1>PROJECTS</h1>
                </div>
            </section>
            <section className={`section ${styles['section-project-list']}`}>
                <h2 className={`section__header`}>Project List</h2>
                <div className={`section__body ${styles['section-project-list__content']}`}>
                    {
                        postCards.map((p, index) => <PostCard key={index}
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

        </div>
    );
};

export default ProjectPage;