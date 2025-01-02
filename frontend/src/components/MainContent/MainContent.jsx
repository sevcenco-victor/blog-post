import {Routes, Route} from "react-router";
import BlogPage from "../../pages/BlogPage/BlogPage.jsx";
import ProjectPage from "../../pages/ProjectPage/ProjectPage.jsx";
import AboutPage from "../../pages/AboutPage/AboutPage.jsx";
import NewsletterPage from "../../pages/NewsletterPage/NewsletterPage.jsx";
import PostPage from "src/pages/PostPage/PostPage.jsx";

const MainContent = () => {
    return (
        <Routes>
            <Route exact path="/" element={<BlogPage/>}/>
            <Route exact path="/post/:postId" element={<PostPage/>}/>
            <Route exact path="projects" element={<ProjectPage/>}/>
            <Route exact path="about" element={<AboutPage/>}/>
            <Route exact path="newsletter" element={<NewsletterPage/>}/>
        </Routes>
    );
};

export default MainContent;