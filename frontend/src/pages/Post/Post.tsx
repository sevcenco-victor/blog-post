import {useEffect, useState} from "react";
import {useParams} from "react-router";
import gfm from 'remark-gfm'
import Markdown from 'react-markdown';
import PostCard from "../../components/Cards/PostCard";
import NewsletterSubscription from "../../components/NewsletterSubscription";
import {DetailedPost, Post as PostType} from "../../types";
import {getLatestPosts, getPostById} from "../../apis/postRequests.ts";
import {POST_PAGE_LATEST_POSTS_NUM} from "../../lib/constants.ts";
import styles from './Post.module.scss';
import TagBadge from "../../components/Badges/TagBadge";


const Post = () => {
    const {postId} = useParams();
    const [markdown, setMarkdown] = useState("");
    const [posts, setPosts] = useState<PostType[]>([]);
    const [postDetails, setPostDetails] = useState<DetailedPost>();

    useEffect(() => {
        const fetchPosts = async (): Promise<void> => {
            const res = await getLatestPosts(POST_PAGE_LATEST_POSTS_NUM);
            setPosts(res);
        }
        const fetchPost = async (): Promise<void> => {
            const res = await getPostById(Number(postId));
            setPostDetails(res);
        }
        fetchPost()
        fetchPosts();
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

    return (
        <div className={`${styles['post-page']}`}>
            <section className={`section ${styles['section-recent-posts']}}`}>
                <h2 className={`section__header`}>Project List</h2>
                <div className={`section__body ${styles['section-recent-posts__content']}`}>
                    {
                        posts.map((p, index) =>
                            <PostCard id={p.id}
                                      key={`recent-posts-${index}`}
                                      imageUrl={p.imageUrl}
                                      postDate={p.postDate}
                                      title={p.title}
                                      text={p.text}
                                      tags={p.tags}
                                      orientation={'portrait'}
                            />)
                    }
                </div>
            </section>
            <section className={`section ${styles['section-post-details']}`}>
                <p className={'badge'}>{postDetails?.postDate}</p>
                <h2>{postDetails?.title}</h2>
                <img src={postDetails?.imageUrl} alt="active-post-photo"/>
                <div className={styles['section-recent-posts__cta']}>
                    <Markdown remarkPlugins={[gfm]}
                              components={{
                                  h1: 'h2'
                              }}>
                        {markdown}
                    </Markdown>
                </div>
                <div className={`${styles['section-post-details__tags']}`}>
                    {postDetails?.tags.map(tag => <TagBadge key={`post-${postId}-tag-${tag.id}`} name={tag.name}
                                                            color={tag.color}/>)}
                </div>

                <NewsletterSubscription/>
            </section>
        </div>
    );
};

export default Post;