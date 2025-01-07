import NewsletterSubscription from "../../components/NewsletterSubscription";
import PostCard from "../../components/Cards/PostCard";
import styles from './Newsletter.module.scss';
import {useEffect, useState} from "react";
import {Post} from "../../types";
import {getLatestPosts} from "../../apis/postRequests.ts";

const Newsletter = () => {
    const [latestPosts, setLatestPosts] = useState<Post[]>([]);

    useEffect(() => {
        const fetchPosts = async () => {
            const res = await getLatestPosts(3);
            setLatestPosts(res);
        }
        fetchPosts();
    }, [])

    return (
        <div className={`${styles['newsletter-page']}`}>
            <NewsletterSubscription/>
            <section className={`section ${styles['section-recent-posts']}`}>
                <h2>Recent Blog Posts</h2>
                <div className={styles['section-recent-posts__content']}>
                    {latestPosts.map((p) =>
                        <PostCard key={`recent-newsletter-posts-${p.id}`}
                                  id={p.id}
                                  imageUrl={p.imageUrl}
                                  title={p.title}
                                  text={p.text}
                                  postDate={p.postDate}
                                  tags={p.tags}
                                  orientation={'portrait'}
                        />)}
                </div>
            </section>
        </div>
    );
};

export default Newsletter;