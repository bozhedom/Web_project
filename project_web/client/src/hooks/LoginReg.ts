import {useState} from "react";

export function useLoginReg() {
    const [login, setLogin] = useState(false)

        try {
            setLogin(true)
        } catch (e: unknown) {
            setLogin(false)

        }


    return {login}

}