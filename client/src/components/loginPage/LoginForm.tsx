import { useState } from "react";
import Input from "../shared/Input"
import Button from "../shared/Button"

interface LoginFormProps {
    onSubmit: (username: string, password: string) => void;
}

const LoginForm: React.FC<LoginFormProps> = ({ onSubmit }) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        onSubmit(username, password);
    };

    return (
        <form onSubmit={handleSubmit} className="flex flex-col items-center gap-4">
        <Input
            name="username"
            placeholder="Username"
            width="w-1/3"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
        />
        <Input
            name="password"
            placeholder="Password"
            type="password"
            width="w-1/3"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
        />
        <Button width="w-1/6" type="submit">Log in</Button>
        </form>
    )
}

export default LoginForm