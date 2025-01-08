import {TagBadgeType} from "@/types";
import styles from './TagBadge.module.scss';


export const TagBadge = ({tag, onClick}: TagBadgeType) => {
    const {name, color} = tag;
    const backgroundStyle = {backgroundColor: color, opacity: 0.1};
    const colorStyle = {color: color};

    return (
        <div className={styles.tagBadge} onClick={onClick}>
            <div className={styles.bg}>
                <div className={styles.mask} style={backgroundStyle}/>
            </div>
            <div className={styles.name} style={colorStyle}>{name}</div>
        </div>
    );
};

export default TagBadge;
