import {Pagination} from "@mui/material";
import {useEffect, useState} from "react";
import {useAxios} from "@/hooks/useAxios.tsx";
import {getLatestPosts, getPosts, getPostsQuantity} from "@/apis/postRequests.ts";
import {GetPaginatedPostRequest, Post} from "@/types";
import {Loader} from "@components";
import {PostCard} from "@components/Cards";
import {determinePageCount} from "@/utils/determinePageCount.ts";
import {BLOG_PAGE_RECENT_POSTS_NUM, BLOG_PAGE_VIEW_POST_QTY} from "@/lib/constants.ts";
import styles from "./Blog.module.scss";


export const Blog = () => {
    const {
        data: latestPosts,
        isLoading: isLoadingRecentPosts,
        error: latestPostsError,
        execute: executeLatestPosts
    } = useAxios<Post[], number>(getLatestPosts);
    const {
        data: postQty,
        isLoading: isLoadingPostQty,
        error: postQtyError,
        execute: executePostQty
    } = useAxios<number, void>(getPostsQuantity);
    const {
        data: allPosts,
        isLoading: isLoadingPosts,
        error: postsError,
        execute: executePosts
    } = useAxios<Post[], GetPaginatedPostRequest>(getPosts);

    const [currPage, setCurrPage] = useState(1);
    const [pageCount, setPageCount] = useState(1);

    useEffect(() => {
        executeLatestPosts(BLOG_PAGE_RECENT_POSTS_NUM).then();
        executePostQty();
    }, []);

    useEffect(() => {
        if (postQty) {
            setPageCount(determinePageCount(postQty, BLOG_PAGE_VIEW_POST_QTY));
        }
    }, [postQty]);

    useEffect(() => {
        executePosts({pageNumber: currPage, postNum: BLOG_PAGE_VIEW_POST_QTY}).then()
    }, [currPage])

    const recentPosts = latestPosts?.slice(0, 3);
    const randomPost = latestPosts?.[3];

    return (
        <>
            <section className={`section section-hero`}>
                <div className={`section-hero__title-wrapper`}>
                    <h1>THE BLOG</h1>
                </div>
            </section>

            <section className={`section ${styles.sectionRecentBlog}`}>
                <h2 className={`section__header`}>Recent blog posts</h2>
                <div className={`section__body ${styles.content}`}>
                    {
                        isLoadingRecentPosts
                            ? <Loader/>
                            : recentPosts?.map((p, index) => {
                                return <PostCard key={p.id}
                                                 {...p}
                                                 orientation={index === 0 ? 'portrait' : 'landscape'}
                                />
                            })
                    }
                </div>
            </section>

            <section className={`section ${styles.sectionRandomBlog}`}>
                <div className={`section__body ${styles.content}`}>
                    {randomPost && <PostCard {...randomPost}/>}
                </div>
            </section>

            <section className={`section ${styles.sectionAllBlogs}`}>
                <h2 className={`section__header`}>All blog posts</h2>
                <div className={`section__body ${styles.content}`}>
                    {isLoadingPosts
                        ? <Loader/>
                        : allPosts?.map((p) =>
                            <PostCard key={`paginated-posts-${p.id}`}
                                      {...p}
                                      orientation={'portrait'}
                            />
                        )
                    }
                </div>
                <hr/>
                {isLoadingPostQty
                    ? <Loader/>
                    : <Pagination count={pageCount} shape={'rounded'}
                                  sx={{
                                      "& .MuiPaginationItem-root": {
                                          color: "var(--font-color)",
                                      },
                                      "& .MuiPaginationItem-root.Mui-selected": {
                                          color: "var(--background-color)",
                                          backgroundColor: "var(--font-color)",
                                      },
                                      "& .MuiPaginationItem-root.Mui-selected:hover": {
                                          color: "var(--background-color)",
                                          backgroundColor: "var(--font-color)",
                                      },
                                  }}
                                  onChange={(_, page) => setCurrPage(page)}
                                  className={styles['pagination']}
                    />
                }
            </section>
        </>
    );
};

export default Blog;