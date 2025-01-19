import {Route} from "react-router-dom";
import {lazy} from "react";
import ProtectedRoute from "@/routes/ProtectedRoute.tsx";

const Account = lazy(() => import("@/pages/(is-logged)/Account/Account.tsx"));
const Preferences = lazy(() => import("@/pages/(is-logged)/Preferences/Preferences.tsx"));
const Profile = lazy(() => import("@/pages/(is-logged)/Profile/Profile.tsx"));
const Security = lazy(() => import("@/pages/(is-logged)/Security/Security.tsx"));
const AddPostForm = lazy(() => import("@/pages/(is-logged)/Post/AddPostForm/AddPostForm.tsx"));
const GetPostForm = lazy(() => import("@/pages/(is-logged)/Post/GetPostForm/GetPostForm.tsx"));

export const AccountRoutes = (
    <Route path="account" element={<ProtectedRoute roles={['User']}><Account/></ProtectedRoute>}>
        <Route path="profile" element={<Profile/>}/>
        <Route path="my-posts" element={<GetPostForm/>}/>
        <Route path="add-post" element={<AddPostForm/>}/>
        <Route path="security" element={<Security/>}/>
        <Route path="preferences" element={<Preferences/>}/>
    </Route>
);

export default AccountRoutes;