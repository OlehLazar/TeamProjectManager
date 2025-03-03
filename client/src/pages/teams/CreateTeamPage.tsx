import { createTeam } from "../../services/teamService";
import axios from "axios";
import Button from "../../components/ui/Button";
import Input from "../../components/ui/Input";
import ErrorMessage from "../../components/ui/ErrorMessage";
import { SubmitHandler, useForm } from "react-hook-form";

type FormFields = {
    name: string;
    description: string;
}

const CreateTeamPage = () => {
    const { register, handleSubmit, formState: { errors }, setError } = useForm<FormFields>();

    const onSubmit: SubmitHandler<FormFields> = async (data) => {
        try {
            await createTeam({ name: data.name, description: data.description });
            window.location.href = "/teams";
        } catch (error) {
            if (axios.isAxiosError(error)) {
                const fieldMapping: { [key: string]: keyof FormFields } = {
                    Name: 'name',
                    Description: 'description',
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
        <form onSubmit={handleSubmit(onSubmit)} className="pt-10 pb-10 flex flex-col justify-center text-center gap-5 mx-auto w-1/2">
            <h1 className="font-ptSerif text-2xl font-semibold">Create a new team</h1>

            <Input {...register('name')} placeholder="Name" width="w-1/3" />
            {errors.name && <ErrorMessage message={errors.name.message!} />}

            <div><textarea {...register('description')} placeholder="Description" className="focus:outline-none border-b border-[#1111116a] p-2 resize-y" /></div>
            {errors.description && <ErrorMessage message={errors.description.message!} />}

            <Button type="submit" width="w-1/5" >Create</Button>
        </form>
    )
}

export default CreateTeamPage