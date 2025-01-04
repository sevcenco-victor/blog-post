import TagBadge from "../../Badges/TagBadge/TagBadge.jsx";
import {Link} from "react-router-dom";
import styles from './PostCard.module.scss'
import PropTypes from "prop-types";

const PostCard = ({id, imageUrl = "", postDate, title, text, tagList, orientation = 'landscape'}) => {

    return (
        <Link to={`/post/${id}`} className={`${styles['post']} ${styles[`post--${orientation}`]}`}>
            <img src={imageUrl} alt="post-image" className={styles['post__image-wrapper']} loading="lazy"/>
            <div className={styles['post__wrapper']}>
                <div className={`${styles['post__post-text']}`}>
                    <p className={`badge ${styles['post__post-date']}`}>{postDate}</p>
                    <h3 className={styles['post__title']}>{title}</h3>
                    <p className={styles['post__text']}>{text}</p>
                </div>
                <div className={styles['post__tag-list']}>
                    {tagList.map((tag, index) => <TagBadge key={index} name={tag.name} color={tag.color}/>)}
                </div>
            </div>
        </Link>
    );
};
PostCard.propTypes = {
    id: PropTypes.number.isRequired,
    imageUrl: PropTypes.string.isRequired,
    postDate: PropTypes.string.isRequired,
    title: PropTypes.string,
    text: PropTypes.string,
    tagList: PropTypes.arrayOf(PropTypes.object),
    orientation: PropTypes.oneOf(['landscape', 'portrait']),
}

export default PostCard;