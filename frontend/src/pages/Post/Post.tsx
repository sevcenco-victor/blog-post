import {useEffect, useState} from "react";
import {useParams} from "react-router";
import gfm from 'remark-gfm'
import Markdown from 'react-markdown';
import {DetailedPost, Post as PostType} from "@/types";
import {useAxios} from "@/hooks/useAxios";
import {getLatestPosts, getPostById} from "@/apis/postRequests";
import {Loader, NewsletterSubscription, TagBadge} from "@components";
import {PostCard} from "@components/Cards";
import {POST_PAGE_LATEST_POSTS_NUM} from "@/lib/constants";
import {formatEditDate, formatDate} from "@/utils/formatDate.ts";
import {Link} from "react-router-dom";
import styles from './Post.module.scss';


export const Post = () => {
    const {postId} = useParams();

    const {
        data: posts,
        isLoading: isLoadingPosts,
        error: errorPosts,
        execute: executePosts,
    } = useAxios<PostType[], number>(getLatestPosts);
    const {
        data: postDetails,
        isLoading: isLoadingPostDetails,
        error: errorPostDetails,
        execute: executePostDetails,
    } = useAxios<DetailedPost, string>(getPostById);

    const [markdown, setMarkdown] = useState("");

    useEffect(() => {
        executePosts(POST_PAGE_LATEST_POSTS_NUM).then();
        executePostDetails(postId || "").then();
    }, [postId]);


    useEffect(() => {
        const fetchMarkdown = async () => {
            if (postDetails) {
                try {
                    const res = await fetch(postDetails.markDownFileLink);
                    if (!res.ok) {
                        throw new Error("Failed to fetch the Markdown file.");
                    }
                    const text = await res.text();
                    setMarkdown(text);
                } catch (err) {
                    console.log(err)
                }
            }
        }
        fetchMarkdown();

    }, [postDetails]);

    const formatedPostDate = formatDate(postDetails?.postDate || "");
    const formatedEditDate = formatEditDate(postDetails?.lastEdit || "");

    const combinedErrors = [errorPostDetails, errorPosts]
        .filter(Boolean)
        .join(',');

    if (combinedErrors) {
        return <p className={'error'}>{combinedErrors}</p>;
    }

    return (
        <div className={`${styles.postPage}`}>
            <section className={`section ${styles.sectionRecentPosts}`}>
                <h2 className={`section__header`}>Project List</h2>
                <div className={`section__body ${styles.content}`}>
                    {
                        isLoadingPosts
                            ? <Loader/>
                            : posts?.map((p, index) =>
                                <PostCard key={`recent-posts-${index}`}
                                          {...p}
                                          orientation={'portrait'}
                                />)
                    }
                </div>
            </section>
            <section className={`section ${styles.sectionPostDetails}`}>
                {isLoadingPostDetails
                    ? <Loader/>
                    : <>
                        <div className={styles.date}>
                            <p className={'badge'}>{`Post Date: ${formatedPostDate}`}</p>
                            <p className={'badge'}>{`Last Edit: ${formatedEditDate}`}</p>
                            <Link to={`/user/${postDetails?.authorUsername}`}>
                                <p className={'badge'}> {`Author: ${postDetails?.authorUsername}`}</p>
                            </Link>

                        </div>
                        <h2>{postDetails?.title}</h2>
                        <img src={postDetails?.imageUrl} alt="active-post-photo"/>
                        <Markdown remarkPlugins={[gfm]}
                                  components={{
                                      h1: 'h2'
                                  }}>
                            {markdown}
                        </Markdown>
                        <div className={styles.tags}>
                            {postDetails?.tags.map(tag => <TagBadge key={`post-${postId}-tag-${tag.id}`} tag={tag}/>)}
                        </div>

                        <NewsletterSubscription/>
                    </>
                }

            </section>
        </div>
    );
};

export default Post;