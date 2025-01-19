import {useEffect, useState} from "react";
import Markdown from "react-markdown";
import {Loader} from "../../components";
import styles from './About.module.scss';

export const About = () => {
    const [content, setContent] = useState('');
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        setIsLoading(true);
        fetch('/about.md')
            .then(res => res.text())
            .then(text => setContent(text))
            .catch(err => console.error('Error fetching markdown file about.md', err))
            .finally(() => setIsLoading(false));
    }, [])

    return (
        <>
            <section className={`section section-hero`}>
                <div className={`section-hero__title-wrapper`}>
                    <h1>MURKIZ</h1>
                </div>
            </section>
            <section className={`section ${styles.sectionAboutMe}`}>
                <img className={styles.img}
                     src="https://i.ytimg.com/vi/rvX8cS-v2XM/maxresdefault.jpg" alt="about-me-photo" loading={"lazy"}/>
                <div className={`section__body ${styles.content}`}>
                    <div className={styles.contentItem}>
                        {isLoading
                            ? <Loader/>
                            : <Markdown>{content}</Markdown>
                        }</div>
                </div>
            </section>
        </>
    );
};

export default About;