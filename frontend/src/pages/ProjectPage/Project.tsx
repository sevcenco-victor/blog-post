import {useEffect, useState} from "react";
import {getPosts} from "../../apis/postRequests.ts";
import PostCard from "../../components/Cards/PostCard/PostCard";
import {Post} from "../../types";
import styles from './Project.module.scss';
import Loader from "../../components/Loader";
import {AxiosError} from "axios";


const Project = () => {
    const [posts, setPosts] = useState<Post[]>([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        const fetchPosts = async () => {
            try {
                const res = await getPosts(5, 1);
                setPosts(res);
            } catch (err) {
                if (err instanceof AxiosError)
                    setError(err.message)
            } finally {
                setIsLoading(false);
            }
        }
        fetchPosts();
    }, [])

    if (isLoading) return <Loader/>;
    if (error) return <p className={'error'}>{error}</p>;

    return (
        <div className={`${styles['project-page']}`}>
            <section className={`section section-hero`}>
                <div className={`section-hero__title-wrapper`}>
                    <h1>PROJECTS</h1>
                </div>
            </section>
            <section className={`section ${styles['section-project-list']}`}>
                <h2 className={`section__header`}>Project List</h2>
                <div className={`section__body ${styles['section-project-list__content']}`}>
                    {
                        posts.map((p) =>
                            <PostCard key={p.id}
                                      id={p.id}
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

        </div>
    );
};

export default Project;