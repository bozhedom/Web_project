import AuthInfo from "../objects/AuthInfo";
import AuthInput from "../objects/AuthInput";
import Repository from "./Repository"

class AuthRepository extends Repository<AuthInput, AuthInfo> {
    constructor() {
        super("auth");
    }

    async login(authInput: AuthInput) {
        let result = await super.postWithData("login", authInput)
        return result;
    }

    async logout() {
        let result = await super.get("logout")
        return result
    }

    async getInfo() {
        let result = await super.get("getInfo")
        return result
    }
}

const authRepository = new AuthRepository();
export default authRepository;