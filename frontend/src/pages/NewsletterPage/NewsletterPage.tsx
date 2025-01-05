import styles from './NewsletterPage.module.scss';
import NewsletterSubscription from "../../components/NewsletterSubscription/NewsletterSubscription";
import PostCard from "../../components/Cards/PostCard/PostCard";

//test cases
const tagList = [
    {name: "Design", color: "#C11574"},
    {name: "Finance", color: "#2ECC71"},
    {name: "HR", color: "#9B59B6"}
];

const postCards = [
    {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    }, {
        imageUrl: 'https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg',
        postDate: "postDate",
        title: "Migrating to Linear 101",
        text: "Linear helps streamline software projects, sprints, tasks, and bug tracking. Here’s how to get...",
        tagList: tagList,
        orientation: "portrait"
    },];

const NewsletterPage = () => {
    return (
        <div className={`${styles['newsletter-page']}`}>
            <NewsletterSubscription/>
            <section className={`section ${styles['section-recent-posts']}`}>
                <h2>Recent Blog Posts</h2>
                <div className={styles['section-recent-posts__content']}>
                    {postCards.map((p, index) =>
                        <PostCard key={index}
                                  id={index}
                                  imageUrl={p.imageUrl}
                                  title={p.title}
                                  text={p.text}
                                  postDate={p.postDate}
                                  tagList={p.tagList}
                                  orientation={'portrait'}
                        />)}
                </div>
            </section>
        </div>
    );
};

export default NewsletterPage;