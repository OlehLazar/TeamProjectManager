import { SubmitHandler, useForm } from "react-hook-form";
import Button from "../ui/Button";
import Input from "../ui/Input";
import { updateProfile } from "../../services/userService";
import axios from "axios";
import ErrorMessage from "../ui/ErrorMessage";

type FormFields = {
  firstName: string;
  lastName: string;
};

const UpdateProfileForm = () => {
    const { register, handleSubmit, formState: { errors }, setError } = useForm<FormFields>();

    const onSubmit: SubmitHandler<FormFields> = async (data) => {
        try {
          await updateProfile({ firstName: data.firstName, lastName: data.lastName });
          window.location.reload();
        } catch (error) {
          console.error("Update failed:", error);
      
            if (axios.isAxiosError(error)) {
                const fieldMapping = {
                    FirstName: 'firstName',
                    LastName: 'lastName',
                } as const;
              
                for (const [field, messages] of Object.entries(error.response?.data?.errors || {})) {
                    const formField = fieldMapping[field as keyof typeof fieldMapping];
                    if (!formField) continue;
              
                    const message = Array.isArray(messages) ? messages.join(' ') : messages;
                    setError(formField, { type: 'server', message: message as string });
                }
            }
        }
    };

    return (
        <form className="flex flex-col gap-4" onSubmit={handleSubmit(onSubmit)}>
            <Input {...register("firstName")} placeholder="First Name" />
            {errors.firstName && <ErrorMessage message={errors.firstName.message!} />}

            <Input {...register("lastName")} placeholder="Last Name" />
            {errors.lastName && <ErrorMessage message={errors.lastName.message!} />}

            <Button type="submit" width="w-full">Confirm</Button>
        </form>
    );
};

export default UpdateProfileForm;
