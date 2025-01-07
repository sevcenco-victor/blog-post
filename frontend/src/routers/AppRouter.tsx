import {Routes, Route} from "react-router-dom";
import {lazy, Suspense} from "react";
import Blog from "../pages/Blog/Blog.tsx";
import AppLayout from "../layouts/AppLayout/AppLayout";
import Loader from "../components/Loader/Loader.tsx";

const ProjectPage = lazy(() => import('../pages/ProjectPage/Project.tsx'));
const AboutPage = lazy(() => import('../pages/About/About.tsx'));
const NewsletterPage = lazy(() => import('../pages/NewsletterPage/Newsletter.tsx'));
const PostPage = lazy(() => import('../pages/Post/Post.tsx'));
const AdminLayout = lazy(() => import('../layouts/AdminLayout/AdminLayout.tsx'));
const AdminPage = lazy(() => import('../pages/(is-logged)/(is-admin)/Admin/Admin.tsx'));
const AdminPostPage = lazy(() => import('../pages/(is-logged)/(is-admin)/AdminPostPage/AdminPost.tsx'));
const AdminTagPage = lazy(() => import('../pages/(is-logged)/(is-admin)/AdminTagPage/AdminTag.tsx'));

const AppRouter = () => {
    return (
        <Suspense fallback={<Loader/>}>
            <Routes>
                <Route element={<AppLayout/>}>
                    <Route index element={<Blog/>}/>
                    <Route path="projects" element={<ProjectPage/>}/>
                    <Route path="about" element={<AboutPage/>}/>
                    <Route path="newsletter" element={<NewsletterPage/>}/>
                    <Route path="post/:postId" element={<PostPage/>}/>
                    <Route path="admin" element={<AdminLayout/>}>
                        <Route index element={<AdminPage/>}/>
                        <Route path="post" element={<AdminPostPage/>}/>
                        <Route path="tag" element={<AdminTagPage/>}/>
                    </Route>
                </Route>
            </Routes>
        </Suspense>

    )
        ;
};

export default AppRouter;