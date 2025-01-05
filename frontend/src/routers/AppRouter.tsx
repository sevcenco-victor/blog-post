import {Routes, Route} from "react-router-dom";
import BlogPage from "../pages/BlogPage/BlogPage";
import PostPage from "../pages/PostPage/PostPage";
import AboutPage from "../pages/AboutPage/AboutPage";
import NewsletterPage from "../pages/NewsletterPage/NewsletterPage";
import AdminLayout from "../layouts/AdminLayout/AdminLayout";
import AdminPage from "../pages/(is-logged)/(is-admin)/AdminPage/AdminPage";
import AdminPostPage from "../pages/(is-logged)/(is-admin)/AdminPostPage/AdminPostPage";
import AdminTagPage from "../pages/(is-logged)/(is-admin)/AdminTagPage/AdminTagPage";
import AppLayout from "../layouts/AppLayout/AppLayout";
import ProjectPage from "../pages/ProjectPage/ProjectPage";

const AppRouter = () => {
    return (
        <Routes>
            <Route element={<AppLayout/>}>
                <Route index element={<BlogPage/>}/>
                <Route path="post/:postId" element={<PostPage/>}/>
                <Route path="projects" element={<ProjectPage/>}/>
                <Route path="about" element={<AboutPage/>}/>
                <Route path="newsletter" element={<NewsletterPage/>}/>
                <Route path="admin" element={<AdminLayout/>}>
                    <Route index element={<AdminPage/>}/>
                    <Route path="post" element={<AdminPostPage/>}/>
                    <Route path="tag" element={<AdminTagPage/>}/>
                </Route>
            </Route>
        </Routes>
    );
};

export default AppRouter;