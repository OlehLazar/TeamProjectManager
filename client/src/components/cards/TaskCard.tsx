import { format } from "date-fns"
import { TaskCardProps } from "../../interfaces/props/TaskCardProps"
import { completeTask } from "../../services/taskService";
import Button from "../ui/Button";
import { getProfile } from "../../services/userService";
import { useQuery } from "@tanstack/react-query";
import { UserDto } from "../../interfaces/dtos/UserDto";

const TaskCard: React.FC<TaskCardProps> = ({ task }) => {
  const startDate = format(task.startDate, "EEE MMM dd yyyy");
  const endDate = format(task.endDate, "EEE MMM dd yyyy");
  console.log(task);

  
  const handleCompleteTask = async () => {
    await completeTask(task.id);
    window.location.reload();
  };

  return (
    <div className="flex flex-col gap-5 p-3 border border-gray-400 rounded-sm shadow-sm shadow-[#11111160] font-openSans">
        <h1 className="font-ptSerif font-semibold text-xl">{task.name}</h1>
        <p>{task.description}</p>
        <p>Start date: {startDate}</p>
        <p>End date:  {endDate}</p>
        <h2>Creator: @{task.creatorUsername}</h2>
        <h2>Assigned to @{task.assigneeUsername}</h2>
        <h2>Status: {task.status ? 'Completed' : 'Uncompleted'}</h2>
        
    </div>
  )
}

export default TaskCard