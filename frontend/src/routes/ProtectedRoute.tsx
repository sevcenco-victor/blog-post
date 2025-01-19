import {ReactNode} from "react";
import {Navigate, useLocation} from "react-router";
import {useAuth} from "@/hooks/useAuth.tsx";

type ProtectedRouteProps = {
    roles: string[];
    children: ReactNode;
}

const ProtectedRoute = ({roles, children}: ProtectedRouteProps) => {
    const {user} = useAuth();
    const location = useLocation();

    if (!user) {
        return <Navigate to={'/login'}
                         replace={true}
                         state={{from: location}}
        />
    }
    if (roles && !roles.includes(user.role)) {
        return <Navigate to={'/unauthorized'} replace={true}/>
    }
    return children;
};

export default ProtectedRoute;