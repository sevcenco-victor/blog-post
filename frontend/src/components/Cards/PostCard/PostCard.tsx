import {Link} from "react-router-dom";
import TagBadge from "../../Badges/TagBadge";
import {Tag} from "../../../types";
import styles from './PostCard.module.scss'

type PostCardProps = {
    id: number;
    imageUrl: string;
    postDate: string;
    title: string;
    text: string;
    tags?: Tag[];
    orientation?: "landscape" | "portrait";
}

const PostCard = ({id, imageUrl, postDate, title, text, tags, orientation = "landscape"}: PostCardProps) => {

    return (
        <Link to={`/post/${id}`} className={`${styles['post']} ${styles[`post--${orientation}`]}`}>
            <img src={imageUrl} alt="post-image" className={styles['post__image-wrapper']} loading="lazy"/>
            <div className={styles['post__wrapper']}>
                <div className={`${styles['post__post-text']}`}>
                    <p className={`badge ${styles['post__post-date']}`}>{postDate}</p>
                    <h3 className={styles['post__title']}>{title}</h3>
                    <p className={styles['post__text']}>{text}</p>
                </div>
                {<div className={styles['post__tag-list']}>
                    {tags?.map((tag) =>
                        <TagBadge key={`post-${id}-tags-${tag.id}`} name={tag.name} color={tag.color}/>
                    )}
                </div>
                }
            </div>
        </Link>
    );
};

export default PostCard;