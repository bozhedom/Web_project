import RoleType from "../enums/RoleType";

type AuthInfo = {
    isAuthenticated: boolean;
    role: RoleType
}

export default AuthInfo;