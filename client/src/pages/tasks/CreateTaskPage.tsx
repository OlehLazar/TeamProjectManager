import { Controller, SubmitHandler, useForm } from "react-hook-form";
import Input from "../../components/ui/Input";
import Button from "../../components/ui/Button";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { createTask } from "../../services/taskService";
import { useParams } from "react-router-dom";
import { getMembers } from "../../services/teamService";
import { UserDto } from "../../interfaces/dtos/UserDto";
import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import ErrorMessage from "../../components/ui/ErrorMessage";

type FormFields = {
    name: string;
    description: string;
    startDate: Date;
    endDate: Date;
    assigneeUsername: string;
};

const CreateTaskPage = () => {
    const params = useParams();
    const boardId = Number(params.boardId);

    const { data: members = [], isLoading, error } = useQuery<UserDto[]>({
        queryKey: ['members'],
        queryFn: () => getMembers(boardId),
    });

    const { register, handleSubmit, control, formState: { errors }, setError } = useForm<FormFields>();

    const onSubmit: SubmitHandler<FormFields> = async (data) => {
        try {
            await createTask({name: data.name, description: data.description, startDate: data.startDate, endDate: data.endDate, boardId: boardId, assigneeUsername: data.assigneeUsername})
        } catch (error) {
            if (axios.isAxiosError(error)) {
                const fieldMapping: { [key: string]: keyof FormFields } = {
                    Name: 'name',
                    Description: 'description',
                    StartDate: 'startDate',
                    EndDate: 'endDate',
                    Assignee: 'assigneeUsername',
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
        <div className="pt-10 pb-10 flex flex-col">
            <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col gap-5 text-center w-1/2 mx-auto">
                <h1 className="font-ptSerif text-2xl">Enter your data</h1>

                <Input {...register("name", { required: "Name is required" })} placeholder="Name" />
                {errors.name && <ErrorMessage message={errors.name.message!} />}

                <Input {...register("description")} placeholder="Description" />
                {errors.description && <ErrorMessage message={errors.description.message!} />}

                <Controller
                    control={control}
                    name="startDate"
                    rules={{ required: "Start date is required" }}
                    render={({ field }) => (
                        <DatePicker
                            selected={field.value}
                            onChange={(date) => field.onChange(date)}
                            placeholderText="Select Start Date"
                            className="border p-2 rounded"
                        />
                    )}
                />
                {errors.startDate && <ErrorMessage message={errors.startDate.message!} />}

                <Controller
                    control={control}
                    name="endDate"
                    rules={{ required: "End date is required" }}
                    render={({ field }) => (
                        <DatePicker
                            selected={field.value}
                            onChange={(date) => field.onChange(date)}
                            placeholderText="Select End Date"
                            className="border p-2 rounded"
                        />
                    )}
                />
                {errors.endDate && <ErrorMessage message={errors.endDate.message!} />}
                
                <Controller
                    control={control}
                    name="assigneeUsername"
                    rules={{ required: "Assignee is required" }}
                    render={({ field }) => (
                        <select
                            {...field}
                            onChange={(e) => field.onChange(e.target.value)}
                            className="w-1/4 p-2 border rounded mx-auto"
                        >
                            <option value="">Select assignee</option>
                            {isLoading ? (
                                <option disabled>Loading members...</option>
                            ) : error ? (
                                <option disabled>Error loading members</option>
                            ) : members.map((member: UserDto) => (
                                <option key={member.userName} value={member.userName}>
                                    {member.userName}
                                </option>
                            ))}
                        </select>
                    )}
                />
                {errors.assigneeUsername && <ErrorMessage message={errors.assigneeUsername.message!} />}

                <Button type="submit" width="w-1/5">Create</Button>
            </form>
        </div>
    );
};

export default CreateTaskPage;
