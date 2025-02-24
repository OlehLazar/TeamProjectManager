import { SubmitHandler, useForm } from "react-hook-form";
import Button from "../ui/Button";
import Input from "../ui/Input";
import { CreateBoardFormProps } from "../../interfaces/props/CreateBoardFormProps";
import { createBoard } from "../../services/boardService";
import axios from "axios";
import ErrorMessage from "../ui/ErrorMessage";

type FormFields = {
    name: string;
    description: string;
}

const CreateBoardForm: React.FC<CreateBoardFormProps> = ({ projectId }) => {
    const { register, handleSubmit, formState: { errors }, setError } = useForm<FormFields>();
    
    const onSubmit: SubmitHandler<FormFields> = async (data) => {
        try {
            await createBoard({name: data.name, description: data.description, projectId: projectId})
            window.location.href = `/projects/${projectId}`;
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
    }

    return (
        <form className="flex flex-col items-center gap-4" onSubmit={handleSubmit(onSubmit)}>
            <h1 className="font-ptSerif text-2xl font-semibold">Create a new board</h1>

            <Input {...register('name')} placeholder="Name" width="w-1/3" />
            {errors.name && <ErrorMessage message={errors.name.message!} />}

            <div><textarea {...register('description')} placeholder="Description" className="focus:outline-none border-b border-[#1111116a]" /></div>
            {errors.description && <ErrorMessage message={errors.description.message!} />}

            <Button width="w-1/6" type="submit">Create</Button>
        </form>
    )
}

export default CreateBoardForm