import {Pagination} from "@mui/material";
import {useEffect, useState} from "react";
import {getLatestPosts, getPosts} from "../../apis/postRequests.ts";
import PostCard from "../../components/Cards/PostCard";
import {Post} from "../../types";
import {BLOG_PAGE_RECENT_POSTS_NUM, BLOG_PAGE_VIEW_POST_QTY} from "../../lib/constants";
import styles from "./Blog.module.scss";


const Blog = () => {
    const [latestPosts, setLatestPosts] = useState<Post[]>([]);
    const [posts, setPosts] = useState<Post[]>([]);
    const [pageNum, setPageNum] = useState(1);

    useEffect(() => {
        const fetchLatestPosts = async () => {
            const res = await getLatestPosts(BLOG_PAGE_RECENT_POSTS_NUM);
            setLatestPosts(res);
        }

        fetchLatestPosts();
    }, []);

    useEffect(() => {
        const fetchPosts = async () => {
            const res = await getPosts(BLOG_PAGE_VIEW_POST_QTY, pageNum);
            setPosts(res);
        }
        fetchPosts();

    }, [pageNum])


    return (
        <div className={`${styles["blog-page"]}`}>
            <section className={`section section-hero`}>
                <div className={`section-hero__title-wrapper`}>
                    <h1>THE BLOG</h1>
                </div>
            </section>

            <section className={`section ${styles['section-recent-blog']}`}>
                <h2 className={`section__header`}>Recent blog posts</h2>
                <div className={`section__body ${styles['section-recent-blog__content']}`}>
                    {
                        latestPosts.slice(0, 3).map((p, index) => {
                            const cardOrientation = index === 0 ? "portrait" : "landscape";

                            return <PostCard key={`latest_posts__${p.id}`}
                                             id={p.id}
                                             imageUrl={p.imageUrl}
                                             title={p.title}
                                             text={p.text}
                                             postDate={p.postDate}
                                             tags={p.tags}
                                             orientation={cardOrientation}

                            />
                        })
                    }
                </div>
            </section>

            <section className={`section ${styles['section-random-blog']}`}>
                <div className={`section__body ${styles['section-random-blog__content']}`}>
                    {
                        latestPosts.slice(3, 4).map((p) =>
                            <PostCard key={`recent-blog__${p.id}`}
                                      id={p.id}
                                      imageUrl={p.imageUrl}
                                      postDate={p.postDate}
                                      title={p.title}
                                      text={p.text}
                                      tags={p.tags}
                            />
                        )
                    }
                </div>
            </section>

            <section className={`section ${styles['section-all-blogs']}`}>
                <h2 className={`section__header`}>All blog posts</h2>
                <div className={`section__body ${styles['section-all-blogs__content']}`}>
                    {posts.map((p) =>
                        <PostCard key={`paginated-posts-${p.id}`} id={p.id} imageUrl={p.imageUrl} postDate={p.postDate}
                                  title={p.title} text={p.text}
                                  tags={p.tags} orientation={'portrait'}/>)
                    }

                    <Pagination count={10} shape={'rounded'}
                                color={'secondary'}
                                onChange={(_, page) => setPageNum(page)}
                                className={styles['pagination']}
                    />
                </div>
            </section>

        </div>
    );
};

export default Blog;