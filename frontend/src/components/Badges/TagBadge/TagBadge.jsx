import styles from './TagBadge.module.scss';

const TagBadge = ({name, color}) => {
    const backgroundStyle = {backgroundColor: color, opacity: 0.1};
    const colorStyle = {color: color};

    return (
        <div className={styles['tag-badge']}>
            <div className={styles['tag-badge__bg']}>
                <div className={styles['tag-badge__bg--mask']} style={backgroundStyle}></div>
            </div>
            <div className={styles['tag-badge__name']} style={colorStyle}>{name}</div>
        </div>
    );
};

export default TagBadge;