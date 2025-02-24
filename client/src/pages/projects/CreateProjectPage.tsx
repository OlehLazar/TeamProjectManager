import { SubmitHandler, useForm } from "react-hook-form";
import { useParams } from "react-router-dom";
import Button from "../../components/ui/Button";
import Input from "../../components/ui/Input";
import { createProject } from "../../services/projectService";
import axios from "axios";
import ErrorMessage from "../../components/ui/ErrorMessage";

type FormFields = {
  name: string;
  description: string;
}

const CreateProjectPage = () => {
  const params = useParams();
  const teamId = Number(params.teamId);

  const { register, handleSubmit, formState: { errors }, setError } = useForm<FormFields>();

  const onSubmit: SubmitHandler<FormFields> = async (data) => {
    try {
      await createProject({name: data.name, description: data.description, teamId})
      window.location.href = `/teams/${teamId}`;
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
    <div>
      <form className="flex flex-col text-center w-1/2 mx-auto gap-4" onSubmit={handleSubmit(onSubmit)}>
        <h1 className="font-ptSerif text-2xl font-semibold">Create a new project</h1>

        <Input {...register('name')} placeholder="Name" width="w-1/3" />
        {errors.name && <ErrorMessage message={errors.name.message!} />}

        <div><textarea {...register('description')} placeholder="Description" className="focus:outline-none border-b border-[#1111116a]" /></div>
        {errors.description && <ErrorMessage message={errors.description.message!} />}

        <Button width="w-1/5" type="submit">Create</Button>
      </form>
    </div>
  )
}

export default CreateProjectPage