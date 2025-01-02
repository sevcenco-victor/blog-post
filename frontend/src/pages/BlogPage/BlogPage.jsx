import PostCard from "../../components/Cards/PostCard/PostCard.jsx";
import {Pagination} from "@mui/material";
import {useEffect, useState} from "react";
import styles from "./BlogPage.module.scss";


const BlogPage = () => {
    const postNum = 6;
    const [pageNum, setPageNum] = useState(1);

    useEffect(() => {
        console.log("Page num: ", pageNum);
    }, [pageNum])

    return (
        <div className={`page ${styles["blog-page"]}`}>
            <section className={`section section-hero`}>
                <div className={`section-hero__title-wrapper`}>
                    <h1>THE BLOG</h1>
                </div>
            </section>

            <section className={`section ${styles['section-recent-blog']}`}>
                <h2 className={`section__header`}>Recent blog posts</h2>
                <div className={`section__body ${styles['section-recent-blog__content']}`}>
                    <PostCard
                        id={1}
                        imageUrl={"https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg"}
                        postDate={"postDate"}
                        title={"Migrating to Linear 101"}
                        text={"Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get..."}
                        tagList={[{name: "Design", color: "#C11574"}]}
                        orientation={"portrait"}/>

                    <PostCard
                        id={2}
                        imageUrl={"https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg"}
                        postDate={"postDate"}
                        title={"Migrating to Linear 101"}
                        text={"Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get..."}
                        tagList={[{name: "Design", color: "#C11574"}]}/>

                    <PostCard
                        id={3}
                        imageUrl={"https://materializecss.com/images/sample-1.jpg"}
                        postDate={"postDate"}
                        title={"Migrating to Linear 101"}
                        text={"Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get..."}
                        tagList={[{name: "Design", color: "#C11574"}]}/>
                </div>
            </section>

            <section className={`section ${styles['section-random-blog']}`}>
                <div className={`section__body ${styles['section-random-blog__content']}`}>
                    <PostCard imageUrl={"https://materializecss.com/images/sample-1.jpg"}
                              postDate={"postDate"}
                              title={"Migrating to Linear 101"}
                              text={"A grid system is a design tool used to arrange content on a webpage. It is a series of vertical and horizontal lines that create a matrix of intersecting points, which can be used to align and organize page elements. Grid systems are used to create a consistent look and feel across a website, and can help to make the layout more visually appealing and easier to navigate."}
                              tagList={[{name: "Design", color: "#C11574"}]}/>
                </div>
            </section>

            <section className={`section ${styles['section-all-blogs']}`}>
                <h2 className={`section__header`}>All blog posts</h2>
                <div className={`section__body ${styles['section-all-blogs__content']}`}>
                    <PostCard imageUrl={"https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg"}
                              postDate={"postDate"}
                              title={"Migrating to Linear 101"}
                              text={"Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get..."}
                              tagList={[{name: "Design", color: "#C11574"}]}
                              orientation={"portrait"}/>
                    <PostCard
                        imageUrl={"https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg"}
                        postDate={"postDate"}
                        title={"Migrating to Linear 101"}
                        text={"Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get..."}
                        tagList={[{name: "Design", color: "#C11574"}]}
                        orientation={"portrait"}/>
                    <PostCard
                        imageUrl={"https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg"}
                        postDate={"postDate"}
                        title={"Migrating to Linear 101"}
                        text={"Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get..."}
                        tagList={[{name: "Design", color: "#C11574"}]}
                        orientation={"portrait"}/>
                    <PostCard
                        imageUrl={"https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg"}
                        postDate={"postDate"}
                        title={"Migrating to Linear 101"}
                        text={"Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get..."}
                        tagList={[{name: "Design", color: "#C11574"}]}
                        orientation={"portrait"}/>
                    <PostCard
                        imageUrl={"https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg"}
                        postDate={"postDate"}
                        title={"Migrating to Linear 101"}
                        text={"Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get..."}
                        tagList={[{name: "Design", color: "#C11574"}]}
                        orientation={"portrait"}/>
                    <PostCard
                        imageUrl={"https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg"}
                        postDate={"postDate"}
                        title={"Migrating to Linear 101"}
                        text={"Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get..."}
                        tagList={[{name: "Design", color: "#C11574"}]}
                        orientation={"portrait"}/>
                </div>

                <Pagination count={10} shape={'rounded'}
                            color={'secondary'}
                            onChange={(_, page) => setPageNum(page)}
                            className={styles['pagination']}
                />

            </section>

        </div>
    );
};

export default BlogPage;