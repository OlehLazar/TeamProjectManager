import { Controller, SubmitHandler, useForm } from "react-hook-form";
import Input from "../../components/ui/Input";
import Button from "../../components/ui/Button";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

type FormFields = {
    name: string;
    description: string;
    startDate: Date;
    endDate: Date;
    boardId: number;
    assigneeUsername: string;
};

const CreateTaskPage = () => {
    const { register, handleSubmit, control, formState: { errors }, setError } = useForm<FormFields>();

    const onSubmit: SubmitHandler<FormFields> = async (data) => {
        console.log(data);
    };

    return (
        <div>
            <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col gap-5 text-center w-1/2 mx-auto">
                <Input {...register("name", { required: "Name is required" })} placeholder="Name" />
                {errors.name && <span className="text-red-500">{errors.name.message}</span>}

                <Input {...register("description")} placeholder="Description" />

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
                {errors.startDate && <span className="text-red-500">{errors.startDate.message}</span>}

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
                {errors.endDate && <span className="text-red-500">{errors.endDate.message}</span>}

                <Button type="submit" width="w-1/5">Create</Button>
            </form>
        </div>
    );
};

export default CreateTaskPage;
