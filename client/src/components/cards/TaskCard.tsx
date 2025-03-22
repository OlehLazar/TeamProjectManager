import { format } from "date-fns"
import { TaskCardProps } from "../../interfaces/props/TaskCardProps"
import { completeTask } from "../../services/taskService";
import Button from "../ui/Button";
import { getProfile } from "../../services/userService";
import { useQuery } from "@tanstack/react-query";
import { UserDto } from "../../interfaces/dtos/UserDto";
import { useMemo } from "react";

const TaskCard: React.FC<TaskCardProps> = ({ task }) => {
  const startDate = useMemo(() => format(task.startDate, "EEE MMM dd yyyy"), [task.startDate]);
  const endDate = useMemo(() => format(task.endDate, "EEE MMM dd yyyy"), [task.endDate]);

  const { data: currentUser } = useQuery<UserDto>({
    queryKey: ["currentUser"],
    queryFn: () => getProfile(),
  });

  const handleCompleteTask = async () => {
    try {
      await completeTask(task.id);
      window.location.reload();
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="flex flex-col gap-5 p-3 border border-[#1111116b] rounded-xl shadow-sm shadow-[#11111160] font-openSans hover:shadow-xl text-lg">
        <h1 className="font-ptSerif font-semibold text-xl text-center">{task.name}</h1>
        <p>{task.description}</p>
        <p>Start date: {startDate}</p>
        <p>End date:  {endDate}</p>
        <h2>Creator: @{task.creatorUsername}</h2>
        <h2>Assigned to @{task.assigneeUsername}</h2>
        <h2>Status: {task.status ? 'Completed' : 'Uncompleted'}</h2>
        {currentUser?.userName === task.assigneeUsername && !task.status && (
          <Button onClick={handleCompleteTask}>Complete Task</Button>
        )}
    </div>
  )
}

export default TaskCard