import {useLocation} from "react-router";
import {useEffect} from "react";

const ScrollToTop = () => {
    const location = useLocation();
    useEffect(() => {
        window.scrollTo(0, 0);
    }, [location]);

    return null;
};

export default ScrollToTop;