import {useEffect, useState} from "react";
import {useAxios} from "@/hooks/useAxios.tsx";
import {getPosts} from "@/apis/postRequests.ts";
import {Loader} from "@components";
import {PostCard} from "@components/Cards";
import {GetPaginatedPostRequest, Post} from "@/types";
import InfiniteScroll from "react-infinite-scroll-component";
import styles from './Project.module.scss';


export const Project = () => {
    const [posts, setPosts] = useState<Post[]>([]);
    const [pageNumber, setPageNumber] = useState(1);
    const [hasMore, setHasMore] = useState(true);

    const {data, error, execute} = useAxios<Post[], GetPaginatedPostRequest>(getPosts);
    const postNum = 2;

    useEffect(() => {
        execute({pageNumber, postNum}).then();
    }, [])

    useEffect(() => {
        if (data) {
            setPageNumber((prevPage) => prevPage + 1);
            setPosts((prevState) => [...prevState, ...data]);
            if (data.length === 0) {
                setHasMore(false);
            }
        }
    }, [data]);

    if (error) return <p className={'error'}>{error}</p>;

    return (
        <>
            <section className={`section section-hero`}>
                <div className={`section-hero__title-wrapper`}>
                    <h1>PROJECTS</h1>
                </div>
            </section>
            <section className={`section`}>
                <h2 className={`section__header`}>Project List</h2>
                <InfiniteScroll
                    className={styles.postWrapper}
                    dataLength={posts.length}
                    next={async () => await execute({pageNumber, postNum})}
                    hasMore={hasMore}
                    loader={<Loader/>}
                >
                    {
                        posts.map((p) => (
                            <PostCard key={p.id}
                                      {...p}
                                      orientation={'portrait'}
                            />
                        ))

                    }
                </InfiniteScroll>
            </section>

        </>
    );
};

export default Project;