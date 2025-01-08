import {Routes, Route} from "react-router-dom";
import {lazy, Suspense} from "react";
import AppLayout from "@/layouts/AppLayout/AppLayout";
import {Loader} from "@/components";
import ScrollToTop from "@/components/navigation";
import {Blog} from "@/pages";
import AccountRoutes from "./AccountRoutes.tsx";
import AdminRoutes from "./AdminRoutes.tsx";

const Project = lazy(() => import('@/pages/Project/Project.tsx'));
const About = lazy(() => import('@/pages/About/About.tsx'));
const Newsletter = lazy(() => import('@/pages/Newsletter/Newsletter.tsx'));
const Post = lazy(() => import('@/pages/Post/Post.tsx'));
const NotFound = lazy(() => import('@/pages/NotFound/NotFound.tsx'));
const SingIn = lazy(() => import('@/pages/SignIn/SignIn.tsx'));
const SignUp = lazy(() => import('@/pages/SignUp/SignUp.tsx'));

const AppRoutes = () => {
    return (
        <Suspense fallback={<Loader/>}>
            <ScrollToTop/>
            <Routes>
                <Route element={<AppLayout/>}>
                    <Route index element={<Blog/>}/>
                    <Route path="projects" element={<Project/>}/>
                    <Route path="about" element={<About/>}/>
                    <Route path="newsletter" element={<Newsletter/>}/>
                    <Route path="post/:postId" element={<Post/>}/>
                    {AccountRoutes}
                    {AdminRoutes}
                    <Route path="/sign-in" element={<SingIn/>}/>
                    <Route path="/sign-up" element={<SignUp/>}/>
                </Route>
                <Route path='*' element={<NotFound/>}/>
            </Routes>
        </Suspense>

    );
};

export default AppRoutes;