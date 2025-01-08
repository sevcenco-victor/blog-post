export  type TagTypes = {
    id: number;
    name: string;
    color: string;
}
export type TagBadgeType = {
    tag: TagTypes
    onClick?: () => void;
}