import { SubmitHandler, useForm } from "react-hook-form"
import Input from "../../components/ui/Input";
import Button from "../../components/ui/Button";
import { login } from "../../services/authService";
import ErrorMessage from "../../components/ui/ErrorMessage";

type FormFields = {
  username: string;
  password: string;
}

const LoginPage = () => {
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
    <div className="pt-10 pb-10 flex flex-col justify-center text-center gap-5 mx-auto w-1/2">
      <form className="flex flex-col items-center gap-4" onSubmit={handleSubmit(onSubmit)}>
        <h1 className="text-2xl font-bold text font-ptSerif">Enter your data:</h1>
        <Input {...register('username')} placeholder="Username" width="w-1/3" />
        <Input {...register('password')} placeholder="Password" type="password" width="w-1/3" />
        {errors.root && <ErrorMessage message={errors.root.message!} />}
        <Button width="w-1/6" type="submit">Log in</Button>
      </form>

      <p>
        Don't have an account yet? <a href="/signup" className="font-semibold hover:font-bold">Sign up now</a>
      </p>
    </div>
  )
}

export default LoginPage