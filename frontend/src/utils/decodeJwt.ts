import {jwtDecode, JwtPayload} from "jwt-decode";
import {User} from "@/types/user.types.ts";


export const decodeJwt = (token: string): User | null => {
    try {
        const decoded: JwtPayload = jwtDecode(token);
        const id: string = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        const role: string = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

        return {id, role};
    } catch (error: any) {
        return null;
    }
}