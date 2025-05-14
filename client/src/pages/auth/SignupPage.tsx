import { SubmitHandler, useForm } from "react-hook-form";
import Input from "../../components/ui/Input";
import Button from "../../components/ui/Button";
import axios from "axios";
import { signup } from "../../services/authService";
import ErrorMessage from "../../components/ui/ErrorMessage";

type FormFields = {
  firstName: string;
  lastName: string;
  userName: string;
  password: string;
  repeatPassword: string;
}

const SignupPage = () => {
  const { register, handleSubmit, formState: { errors }, setError } = useForm<FormFields>();

  const onSubmit: SubmitHandler<FormFields> = async (data) => {
    if (data.password !== data.repeatPassword) {
      setError( 'repeatPassword', {
          message: "Passwords need to match"
      });
    }
    try {
      await signup({firstName: data.firstName, lastName: data.lastName, userName: data.userName, password: data.password});
      window.location.href = "/";
    } catch (error) {
      console.error("Update failed:", error);
  
      if (axios.isAxiosError(error)) {
        const fieldMapping: { [key: string]: keyof FormFields } = {
          FirstName: 'firstName',
          LastName: 'lastName',
          UserName: 'userName',
          Password: 'password',
        };

        const serverErrors = error.response?.data?.errors;
        Object.entries(serverErrors).forEach(([field, messages]) => {
          const formField = fieldMapping[field];
          const errorMessage = Array.isArray(messages) 
          ? messages.join(" ") 
          : (messages as string);
    
          if (formField) {
            setError(formField, {
              type: "server",
              message: errorMessage
            });
          }
        });
      }
    }
  };

  return (
    <div className="pt-10 pb-10 flex flex-col justify-center text-center gap-5 mx-auto w-full sm:w-4/5 lg:w-1/2 xl:w-2/5">
      <form className="flex flex-col items-center gap-4" onSubmit={handleSubmit(onSubmit)}>
        <h1 className="text-2xl font-bold text font-ptSerif">Enter your data:</h1>
        
        <Input {...register('firstName')} placeholder="First Name" width="w-1/3" />
        {errors.firstName && <ErrorMessage message={errors.firstName.message!}/>}
        
        <Input {...register('lastName')} placeholder="Last Name" width="w-1/3" />
        {errors.lastName && <ErrorMessage message={errors.lastName.message!} />}

        <Input {...register('userName')} placeholder="Username" width="w-1/3" />
        {errors.userName && <ErrorMessage message={errors.userName.message!} />}

        <Input {...register('password')} type="password" placeholder="Password" width="w-1/3" />
        {errors.password && <ErrorMessage message={errors.password.message!} />}

        <Input {...register('repeatPassword')} type="password" placeholder="Repeat Password" width="w-1/3" />
        {errors.repeatPassword && <ErrorMessage message={errors.repeatPassword.message!} />}
        
        <Button width="w-1/6" type="submit">Sign up</Button>
      </form>
    </div>
  )
}

export default SignupPage