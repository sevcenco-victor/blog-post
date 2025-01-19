import {Link} from "react-router-dom";
import {TagBadge} from '@components';
import {TagTypes} from "@/types";
import {formatDate} from "@/utils/formatDate.ts";
import styles from './PostCard.module.scss'

type PostCardProps = {
    id: number;
    imageUrl: string;
    postDate: string;
    title: string;
    text: string;
    tags?: TagTypes[];
    orientation?: "landscape" | "portrait";
}


export const PostCard = ({id, imageUrl, postDate, title, text, tags, orientation = "landscape"}: PostCardProps) => {
    const atLeastOneTag: boolean = tags != undefined && tags.length > 0;
    const formatedDate = formatDate(postDate);
    const orientationStyle = orientation === "landscape" ? styles.landscape : styles.portrait;

    return (
        <Link to={`/post/${id}`} className={`${styles.post} ${orientationStyle}`}>
            <img src={imageUrl} alt="post-image" className={styles.imageWrapper} loading="lazy"/>
            <div className={styles.wrapper}>
                <div className={`${styles.contentWrapper}`}>
                    <p className={`badge`}>{formatedDate}</p>
                    <h3 className={styles.truncate}>{title}</h3>
                    <p className={`${styles.truncate} ${styles.text}`}>{text}</p>
                </div>
                {atLeastOneTag &&
                    <div className={`${styles.tagList}`}>
                        {tags!.slice(0, 3).map((tag) =>
                            <TagBadge key={`post-${id}-tags-${tag.id}`} tag={tag}/>
                        )}
                    </div>
                }
            </div>
        </Link>
    );
};

export default PostCard;