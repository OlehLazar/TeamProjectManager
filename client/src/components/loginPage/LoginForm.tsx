import { SubmitHandler, useForm } from "react-hook-form"
import Input from "../shared/Input"
import Button from "../shared/Button"
import { login } from "../../services/authService";

type FormFields = {
    username: string;
    password: string;
}

const LoginForm: React.FC = () => {
    const { register, handleSubmit, formState: { errors }, setError } = useForm<FormFields>();

    const onSubmit: SubmitHandler<FormFields> = async (data) => {
        try {
            await login({ userName: data.username, password: data.password });
            window.location.href = "/";
        } catch (error) {
            console.error("Login failed:", error);
            setError('root', {
                type: 'invalidCredentials',
                message: 'Invalid credentials'
            });
        }
    }

    return (
        <form className="flex flex-col items-center gap-4" onSubmit={handleSubmit(onSubmit)}>
            <Input {...register('username')} name="username" placeholder="Username" width="w-1/3" />
            <Input {...register('password')} name="password" placeholder="Password" type="password" width="w-1/3" />
            <Button width="w-1/6" type="submit">Log in</Button>
            {errors.root && errors.root.type === 'invalidCredentials' && (
                <span role="alert" className="text-md text-red-500">
                    {errors.root.message}
                </span>
            )}
        </form>
    )
}

export default LoginForm