import {useContext} from "react";
import {AuthContextType} from "@/types";
import {AuthContext} from "@/provider/AuthContext.tsx";

export const useAuth = (): AuthContextType => {
    const context = useContext(AuthContext);
    if (context === null) {
        throw new Error("useAuth must be used within the AuthProvider");
    }
    return context;
};