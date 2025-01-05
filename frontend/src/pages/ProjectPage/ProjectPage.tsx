import axiosInstance from "../../apis/axiosInstance";
import useAxios from "../../hooks/useAxios";
import PostCard from "../../components/Cards/PostCard/PostCard";
import {PostResponse} from "../../types/PostResponse";
import styles from './ProjectPage.module.scss';


const ProjectPage = () => {
    const {response = [], error, loading} = useAxios<PostResponse[]>({
        axiosInstance,
        url: "/post",
        method: "get",
    });

    if (loading) {
        return <p>Loading...</p>
    }
    if (error) {
        return <p>{error}</p>
    }

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
                        response.map((p: PostResponse) =>
                            <PostCard key={p.id}
                                      id={p.id}
                                      imageUrl={p.imageUrl}
                                      postDate={p.postDate}
                                      title={p.title}
                                      text={p.text}
                                      tagList={p.tagList}
                                      orientation={"portrait"}
                            />)
                    }
                </div>
            </section>

        </div>
    );
};

export default ProjectPage;