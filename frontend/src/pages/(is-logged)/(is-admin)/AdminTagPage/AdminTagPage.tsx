import useAxios from "../../../../hooks/useAxios";
import axiosInstance from "../../../../apis/axiosInstance";
import Button from "../../../../components/Buttons/PrimaryButton/Button";
import {Tag} from "../../../../types/Tag";
import styles from './AdminTagPage.module.scss';

const AdminTagPage = () => {
    const {response = [], error, loading, refetch} = useAxios<Tag[]>({
        axiosInstance,
        method: "get",
        url: "/tag",
    });

    if (loading) {
        return <p>Loading...</p>
    }
    if (error.length > 0) {
        return <p>{error}</p>;
    }
    return (
        <div>
            {response.map((tag: Tag, index) => <p key={index}>{tag.name}</p>)}
            <Button text={'fetch'} onClick={refetch}/>
        </div>
    );
};

export default AdminTagPage;