import styles from './About.module.scss';
import Markdown from "react-markdown";
import {useEffect, useState} from "react";

const About = () => {

    const [content, setContent] = useState('');

    useEffect(() => {
        fetch('/about.md')
            .then(res => res.text())
            .then(text => setContent(text))
            .catch(err => console.error('Error fetching markdown file about.md', err));
    }, [])

    return (
        <div className={`${styles['about-page']}`}>
            <section className={`section section-hero`}>
                <div className={`section-hero__title-wrapper`}>
                    <h1>MURKIZ</h1>
                </div>
            </section>
            <section className={`section ${styles['section-about-me']}`}>
                <img className={styles['section-about-me__image']}
                     src="https://i.ytimg.com/vi/rvX8cS-v2XM/maxresdefault.jpg" alt="about-me-photo"/>
                <div className={`section__body ${styles['section-about-me__content']}`}>
                    <div className={styles['content__item']}>
                        <Markdown>{content}</Markdown>
                    </div>
                </div>
            </section>
        </div>
    );
};

export default About;