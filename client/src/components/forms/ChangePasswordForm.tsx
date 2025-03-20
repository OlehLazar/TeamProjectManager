import { SubmitHandler, useForm } from "react-hook-form";
import { changePassword } from "../../services/userService"
import Input from "../ui/Input";
import Button from "../ui/Button";
import axios from "axios";
import ErrorMessage from "../ui/ErrorMessage";

type FormFields = {
    oldPassword: string;
    newPassword: string;
    confirmPassword: string;
}

const ChangePasswordForm = () => {
    const { register, handleSubmit, formState: { errors }, setError } = useForm<FormFields>();
    
    const onSubmit: SubmitHandler<FormFields> = async (data) => {
        if (data.newPassword !== data.confirmPassword) {
            setError('root', {
                message: "New passwords do not match"
            });
            return;
        }
        try {
            await changePassword({oldPassword: data.oldPassword, newPassword: data.newPassword});
            window.location.reload();
        } catch (error) {
            console.error("Change failed:", error)
            let message = "An unexpected error occured.";
           
            if (axios.isAxiosError(error)) {
                const errors = error.response?.data?.errors;
                if (errors) {
                    message = Object.values(errors).flat().join(); 
                } else {
                    message = String(error.response?.data);
                }   
            }

            setError('root', {
                message: message
            });
        }
    }

    return (
        <form className="flex flex-col gap-4" onSubmit={handleSubmit(onSubmit)}>
            <Input {...register("oldPassword")} type="password" placeholder="Old Password" />
            <Input {...register("newPassword")} type="password" placeholder="New Password" />
            {errors.root && <ErrorMessage message={errors.root.message!} />}
            <Input {...register("confirmPassword")} type="password" placeholder="Confirm New Password" />
            <Button type="submit" width="w-full">Confirm</Button>
        </form>
    )
}

export default ChangePasswordForm