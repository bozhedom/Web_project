import React, {useState} from "react";
import "./LoginRegPage.css";
import {Login} from "../components/Login";
import {Registration} from "../components/Registration";
import Button from "@mui/material/Button";

export function LoginRegPage() {
    const [login, setLogin] = useState(true)

    return (
        <>
            <div>
                {login ? <Login /> : <Registration />}

                <Button
                    type="submit"
                    variant="contained"
                    sx={{ mt: 3, mb: 2, ml: 83 }}
                    onClick={() => setLogin(!login)}
                >
                    {login ? 'Зарегистрироватся': 'Войти'}
                </Button>

            </div>
        </>
    )
}