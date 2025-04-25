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
    <div className="pt-10 pb-10 flex flex-col justify-center text-center gap-5 mx-auto w-full px-4 sm:w-4/5 lg:w-1/2 xl:w-2/5">
      <form className="flex flex-col items-center gap-4 w-1/2 mx-auto" onSubmit={handleSubmit(onSubmit)}>
        <h1 className="text-2xl font-bold text font-ptSerif">Enter your data:</h1>
        <Input 
          {...register('username')} 
          placeholder="Username" 
          width="w-full sm:w-4/5 md:w-3/4 lg:w-2/3" 
        />
        <Input 
          {...register('password')} 
          placeholder="Password" 
          type="password" 
          width="w-full sm:w-4/5 md:w-3/4 lg:w-2/3" 
        />
        {errors.root && <ErrorMessage message={errors.root.message!} />}
        <Button width="w-full sm:w-2/5 md:w-1/3 lg:w-1/2" type="submit">
          Log in
        </Button>
      </form>

      <p className="px-2 sm:px-0">
        Don't have an account yet?{' '}
        <a href="/signup" className="font-semibold hover:font-bold transition-all">
          Sign up now
        </a>
      </p>
    </div>
  )
}

export default LoginPage