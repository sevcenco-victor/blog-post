import {Outlet} from "react-router";
import {MenuBar, MenuBarGroup, MenuBarItem} from "@components/MenuBar";
import {useAuth} from "@/hooks/useAuth.tsx";

export const AdminAccount = () => {
    const {logout} = useAuth();
    return (
        <div className={'account-layout'}>
            <MenuBar>
                <MenuBarGroup groupName={'DASHBOARD'}>
                    <MenuBarItem to={'dashboard'} text={'Dashboard'}/>
                </MenuBarGroup>
                <MenuBarGroup groupName={'USERS'}>
                    <MenuBarItem to={'users'} text={'Users'}/>
                </MenuBarGroup>
                <MenuBarGroup groupName={'CONTENT CONTROL'}>
                    <MenuBarItem to={'posts'} text={'Posts'}/>
                    <MenuBarItem to={'comments'} text={'Comments'}/>
                    <MenuBarItem to={'tags'} text={'Tags'}/>
                </MenuBarGroup>
                <MenuBarGroup groupName={'SUPPORT'}>
                    <MenuBarItem to={'help'} text={'Help'}/>
                    <MenuBarItem to={'#'} onClick={() => logout()} text={'Log Out'}/>
                </MenuBarGroup>
            </MenuBar>
            <Outlet/>
        </div>
    );
};

export default AdminAccount;