import {useEffect, useState} from "react";
import {useParams} from "react-router";
import gfm from 'remark-gfm'
import Markdown from 'react-markdown';
import PostCard from "src/components/Cards/PostCard/PostCard.jsx";
import NewsletterSubscription from "src/components/NewsletterSubscription/NewsletterSubscription.jsx";
import useAxios from "src/hooks/useAxios.jsx";
import axiosInstance from 'src/apis/axiosInstance.jsx';
import {mockPosts} from "src/mock/mockPosts.js";
import 'react-markdown-editor-lite/lib/index.css';
import styles from './PostPage.module.scss';

const PostPage = () => {
    const {postId} = useParams();
    const [markdown, setMarkdown] = useState("");
    const {response, error, loading} = useAxios({
            axiosInstance,
            url: `/post/${postId}`,
            method: 'get'
        }
    )

    useEffect(() => {
        const fetchMarkdown = async () => {
            try {
                const res = await fetch(response.markDownFileLink);
                if (!res.ok) {
                    throw new Error("Failed to fetch the Markdown file.");
                }
                const text = await res.text();
                setMarkdown(text);
            } catch (err) {
                console.log(err)
            }
        }

        if (response) {
            fetchMarkdown();
        }
    }, [response]);

    if (!markdown || loading) return <p>Loading...</p>;

    if (error) {
        return <p>{error}</p>
    }

    return (
        <div className={`${styles['post-page']}`}>
            <section className={`section ${styles['section-recent-posts']}}`}>
                <h2 className={`section__header`}>Project List</h2>
                <div className={`section__body ${styles['section-recent-posts__content']}`}>
                    {
                        mockPosts.map((p, index) => <PostCard id={index} key={index}
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
                <p className={'badge'}>{response.postDate}</p>
                <h2>{response.title}</h2>
                <img src={response.imageUrl} alt="active-post-photo"/>
                <div className={styles['section-recent-posts__cta']}>
                    <Markdown remarkPlugins={[gfm]}>
                        {markdown}
                    </Markdown>
                    <NewsletterSubscription/>
                </div>
            </section>
        </div>
    );
};

export default PostPage;