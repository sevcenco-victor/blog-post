import {useEffect} from "react";
import {getLatestPosts} from "@/apis/postRequests.ts";
import {useAxios} from "../../hooks/useAxios.tsx";
import {Post} from "@/types";
import {Loader, NewsletterSubscription} from "@components";
import {PostCard} from "@components/Cards";
import styles from './Newsletter.module.scss';

export const Newsletter = () => {
    const {data: latestPosts, isLoading, error, execute} = useAxios<Post[], number>(getLatestPosts);

    useEffect(() => {
        execute(3).then();
    }, [])


    if (error) {
        return <p className={'error'}>{error}</p>
    }

    return (
        <>
            <NewsletterSubscription/>
            <section className={`section ${styles.sectionRecentPosts}`}>
                <h2>Recent Blog Posts</h2>
                <div className={styles.content}>
                    {isLoading
                        ? <Loader/>
                        : latestPosts?.map((p) =>
                            <PostCard key={`recent-newsletter-posts-${p.id}`}
                                      {...p}
                                      orientation={'portrait'}
                            />)}
                </div>
            </section>
        </>
    );
};

export default Newsletter;