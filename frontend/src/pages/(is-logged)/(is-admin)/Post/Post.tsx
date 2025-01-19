import {SyntheticEvent, useState} from 'react';
import {TabContext, TabList, TabPanel} from '@mui/lab'
import {Tab} from '@mui/material';
import {DeletePostForm, GetPostForm} from "../../Post";
import tabStyles from '@/styles/components/tabs.module.scss';


export const Post = () => {
    const [value, setValue] = useState('get');
    const handleChange = (newValue: string) => {
        setValue(newValue);
    }

    return (
        <div>
            <TabContext value={value}>
                <TabList onChange={(_: SyntheticEvent, v: string) => handleChange(v)}
                         aria-label='post-actions'
                         textColor={'inherit'}
                         TabIndicatorProps={{className: tabStyles.tabIndicator}}>
                    <Tab label='Get' value='get'/>
                    <Tab label='Delete' value='delete'/>
                </TabList>
                <TabPanel className={tabStyles.tabPanel} value='get'>{<GetPostForm/>}</TabPanel>
                <TabPanel className={tabStyles.tabPanel} value='delete'>{<DeletePostForm/>}</TabPanel>
            </TabContext>
        </div>
    );
};

export default Post;