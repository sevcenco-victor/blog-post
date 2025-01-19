import {useEffect, useState} from "react";
import InfiniteScroll from "react-infinite-scroll-component";
import {SelectChangeEvent} from "@mui/material";
import useDebounce from "@/hooks/useDebounce.tsx";
import {DEBOUNCE_DELAY} from "@/lib/constants.ts";
import {GetPaginatedPostRequest, Post, TagTypes} from "@/types";
import {Loader, Input} from "@components";
import {PostCard} from "@components/Cards";
import {FormLabel} from "@components/Form";
import {useAxios} from "@/hooks/useAxios.tsx";
import {getUserPosts} from "@/apis/postRequests.ts";
import {getTags} from "@/apis/tagRequests.ts";
import StyledSelect from "@components/styled/StyledSelect.tsx";
import {useAuth} from "@/hooks/useAuth.tsx";
import styles from "./GetPostForm.module.scss";

export const GetPostForm = () => {
    const {user} = useAuth();
    const [query, setQuery] = useState('');
    const [posts, setPosts] = useState<Post[]>([]);
    const [hasMore, setHasMore] = useState(true);
    const [pageNumber, setPageNumber] = useState(1);
    const [selectedTagList, setSelectedTagList] = useState<TagTypes[]>([]);

    const {data, error: postError, execute: executeGetPosts} = useAxios<Post[], GetPaginatedPostRequest>(getUserPosts);
    const {
        data: tags,
        isLoading: isLoadingGetTags,
        error: errorGetTags,
        execute: executeGetTags
    } = useAxios<TagTypes[], void>(getTags);

    const debouncedSearch = useDebounce<string>(query, DEBOUNCE_DELAY)

    const pageSize = 6;

    const resetData = () => {
        setPosts([]);
        setHasMore(true);
        setPageNumber(1);
    }

    const fetchNextPage = () => {
        executeGetPosts({
            pageNumber,
            postNum: pageSize,
            title: query,
            tagIds: selectedTagList.map(t => t.id)
        }).then();
    }

    useEffect(() => {
        executeGetTags().then();
    }, []);

    useEffect(() => {
        resetData();
        executeGetPosts({
            userId: user!.id,
            pageNumber: 1,
            postNum: pageSize,
            title: query,
            tagIds: selectedTagList.map(t => t.id)
        }).then();
    }, [selectedTagList, debouncedSearch]);

    useEffect(() => {
        if (data) {
            setPosts(prev => [...prev, ...data]);
            setPageNumber(prev => prev + 1);
            if (data.length === 0) {
                setHasMore(false);
            }
        }
    }, [data]);


    const combinedError = [postError, errorGetTags]
        .filter(Boolean)
        .join(", ");

    if (combinedError) {
        return <p className={'error'}>{combinedError}</p>
    }
    if (isLoadingGetTags) {
        return <Loader/>
    }
    const handleChange = (event: SelectChangeEvent<TagTypes[]>) => {
        const {value} = event.target;
        setSelectedTagList(value as TagTypes[]);
    };
    return (
        <div className={styles.getPostForm}>
            <div className={styles.header}>
                <FormLabel text={"Search"}>
                    <Input name="search" type={'search'} placeholder={'barking '}
                           onChange={(e) => setQuery(e.target.value)}/>
                </FormLabel>
                <StyledSelect<TagTypes> options={tags} onChange={handleChange} value={selectedTagList}/>
            </div>
            <InfiniteScroll
                className={styles.postsWrapper}
                dataLength={posts.length}
                next={fetchNextPage}
                hasMore={hasMore}
                loader={<Loader/>}
            >
                {posts.map((p) => (
                    <PostCard key={`get-post-${p.id}`} {...p} orientation={'portrait'}/>
                ))}
            </InfiniteScroll>
        </div>
    )
        ;
}
export default GetPostForm;