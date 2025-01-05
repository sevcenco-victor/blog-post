import {Outlet} from "react-router";

const AppLayout = () => {
    return (
        <div className={`page`}>
            <Outlet/>
        </div>
    );
};

export default AppLayout;