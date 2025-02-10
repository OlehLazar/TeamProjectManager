import { useState } from "react";
import { login } from "../../services/authService";
import Input from "../shared/Input"
import Button from "../shared/Button"

const LoginForm: React.FC = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [errorMessage, setErrorMessage] = useState("");

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            await login({ userName: username, password: password });
            window.location.href = "/";
        } catch (error) {
            console.error("Login failed:", error);
            setErrorMessage("Invalid credentials");
        }
    };

    return (
        <form onSubmit={handleSubmit} className="flex flex-col items-center gap-4">
            <Input name="username" placeholder="Username" width="w-1/3" value={username} onChange={(e) => setUsername(e.target.value)} />
            <Input name="password" placeholder="Password" type="password" width="w-1/3" value={password} onChange={(e) => setPassword(e.target.value)} />
            <Button width="w-1/6" type="submit">Log in</Button>
            {errorMessage && <p className="text-red-500 mt-2">{errorMessage}</p>}
        </form>
    )
}

export default LoginForm