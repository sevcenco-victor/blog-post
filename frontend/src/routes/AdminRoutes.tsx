import {lazy} from 'react';
import {Route} from "react-router-dom";
import ProtectedRoute from "@/routes/ProtectedRoute.tsx";

const AdminAccount = lazy(() => import("@/pages/(is-logged)/(is-admin)/Admin/AdminAccount.tsx"));
const Dashboard = lazy(() => import("@/pages/(is-logged)/(is-admin)/Dashboard/Dashboard.tsx"));
const Users = lazy(() => import("@/pages/(is-logged)/(is-admin)/Users/Users.tsx"));
const Post = lazy(() => import("@/pages/(is-logged)/(is-admin)/Post/Post.tsx"));
const Comments = lazy(() => import("@/pages/(is-logged)/(is-admin)/Comments/Comments.tsx"));
const Tags = lazy(() => import("@/pages/(is-logged)/(is-admin)/Tags/Tags.tsx"));

export const AdminRoutes = (
    <Route path="admin" element={<ProtectedRoute roles={['Admin']}><AdminAccount/></ProtectedRoute>}>
        <Route path="dashboard" element={<Dashboard/>}/>
        <Route path="users" element={<Users/>}/>
        <Route path="posts" element={<Post/>}/>
        <Route path="comments" element={<Comments/>}/>
        <Route path="tags" element={<Tags/>}/>
    </Route>
);

export default AdminRoutes;