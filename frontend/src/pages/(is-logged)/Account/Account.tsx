import {Outlet} from "react-router";
import {MenuBar, MenuBarGroup, MenuBarItem} from "@components/MenuBar";
import {useAuth} from "@/hooks/useAuth.tsx";

export const Account = () => {
    const {logout} = useAuth();

    return (
        <div className={'account-layout'}>
            <MenuBar>
                <MenuBarGroup groupName={'ACCOUNT'}>
                    <MenuBarItem to={'profile'} text={'Profile'}/>
                </MenuBarGroup>
                <MenuBarGroup groupName={'BLOG'}>
                    <MenuBarItem to={'my-posts'} text={'My Posts'}/>
                    <MenuBarItem to={'add-post'} text={'Add Post'}/>
                </MenuBarGroup>
                <MenuBarGroup groupName={'SETTINGS'}>
                    <MenuBarItem to={'security'} text={'Security'}/>
                    <MenuBarItem to={'preferences'} text={'Preferences'}/>
                </MenuBarGroup>
                <MenuBarGroup groupName={'SUPPORT'}>
                    <MenuBarItem to={'help'} text={'Security'}/>
                    <MenuBarItem to={'#'} onClick={() => logout()} text={'Log Out'}/>
                </MenuBarGroup>
            </MenuBar>
            <Outlet/>
        </div>
    );
};

export default Account;