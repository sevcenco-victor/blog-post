import PostCard from "src/components/Cards/PostCard/PostCard.jsx";
import useAxios from "src/hooks/useAxios.jsx";
import axiosInstance from "src/apis/axiosInstance.jsx";
import styles from './ProjectPage.module.scss';

const ProjectPage = () => {

    const {response, error, loading} = useAxios({
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
                        response.map((p) => <PostCard key={p.id}
                                                      id={p.id}
                                                      imageUrl={p.imageUrl}
                                                      postDate={p.postDate}
                                                      title={p.title}
                                                      text={p.text}
                                                      tagList={p.tags}
                                                      orientation={'vertical'}
                        />)
                    }
                </div>
            </section>

        </div>
    );
};

export default ProjectPage;