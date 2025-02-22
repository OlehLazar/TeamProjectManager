import { SubmitHandler, useForm } from "react-hook-form";
import Input from "../ui/Input"
import Button from "../ui/Button";
import { addMember } from "../../services/teamService";
import axios from "axios";
import { useParams } from "react-router-dom";

type FormFields = {
    username: string;
}

const AddMemberForm = () => {
    const params = useParams();
    const teamId = Number(params.teamId);

    const { register, handleSubmit, formState: { errors }, setError } = useForm<FormFields>();
    
    const onSubmit: SubmitHandler<FormFields> = async (data) => {
        try {
            await addMember(teamId, data.username);
            window.location.reload();
        } catch (error) {
            console.error("Adding failed:", error);
            
            let message = "An unexpected error occured.";
           
            if (axios.isAxiosError(error)) {
                const errors = error.response?.data?.errors;
                if (errors) {
                    message = Object.values(errors).flat().join(); 
                } else {
                    message = String(error.response?.data.message);
                }   
            }

            setError('root', {
                message: message
            });
        }
    }

    return (
        <form className="flex flex-col p-4 items-center gap-4 border border-[#737272] rounded-xl shadow-md shadow-[#11111170] w-1/4 bg-w mx-auto" onSubmit={handleSubmit(onSubmit)}>
            <h1 className="font-ptSerif font-semibold text-2xl">Enter the username</h1>
            <Input {...register('username')} placeholder="Username" width="w-1/2" />
            {errors.root && (<span role="alert" className="text-md text-red-500">{errors.root.message}</span>)}
            <Button width="w-1/2" type="submit">Add</Button>
        </form>
    )
}

export default AddMemberForm