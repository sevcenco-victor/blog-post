import {Routes, Route} from "react-router";
import BlogPage from "../../pages/BlogPage/BlogPage.jsx";
import ProjectPage from "../../pages/ProjectPage/ProjectPage.jsx";
import AboutPage from "../../pages/AboutPage/AboutPage.jsx";
import NewsletterPage from "../../pages/NewsletterPage/NewsletterPage.jsx";
import PostPage from "src/pages/PostPage/PostPage.jsx";
import AdminPage from "src/pages/Admin/AdminPage/AdminPage.jsx";
import AdminPostPage from "src/pages/Admin/AdminPostPage/AdminPostPage.jsx";
import AppLayout from "src/layouts/AppLayout/AppLayout.jsx";
import AdminLayout from "src/layouts/AdminLayout/AdminLayout.jsx";
import AdminTagPage from "src/pages/Admin/AdminTagPage/AdminTagPage.jsx";

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