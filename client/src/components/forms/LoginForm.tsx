import { SubmitHandler, useForm } from "react-hook-form"
import Input from "../ui/Input"
import Button from "../ui/Button"
import { login } from "../../services/authService";
import ErrorMessage from "../ui/ErrorMessage";

type FormFields = {
    username: string;
    password: string;
}

const LoginForm = () => {
    const { register, handleSubmit, formState: { errors }, setError } = useForm<FormFields>();

    const onSubmit: SubmitHandler<FormFields> = async (data) => {
        try {
            await login({ userName: data.username, password: data.password });
            window.location.href = "/";
        } catch (error) {
            console.error("Login failed:", error);
            setError('root', {
                message: 'Invalid credentials'
            });
        }
    }

    return (
        <form className="flex flex-col items-center gap-4" onSubmit={handleSubmit(onSubmit)}>
            <h1 className="text-2xl font-bold text font-ptSerif">Enter your data:</h1>
            <Input {...register('username')} placeholder="Username" width="w-1/3" />
            <Input {...register('password')} placeholder="Password" type="password" width="w-1/3" />
            {errors.root && <ErrorMessage message={errors.root.message!} />}
            <Button width="w-1/6" type="submit">Log in</Button>
        </form>
    )
}

export default LoginForm