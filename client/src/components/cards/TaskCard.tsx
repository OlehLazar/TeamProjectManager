import { format } from "date-fns"
import { TaskCardProps } from "../../interfaces/props/TaskCardProps"

const TaskCard: React.FC<TaskCardProps> = ({ task }) => {
  const startDate = format(task.startDate, "EEE MMM dd yyyy");
  const endDate = format(task.endDate, "EEE MMM dd yyyy");

  return (
    <div className="flex flex-col gap-5 p-3 border border-gray-400 rounded-sm shadow-sm shadow-[#11111160]">
        <h1 className="font-ptSerif font-semibold text-xl">{task.name}</h1>
        <p>{task.description}</p>
        <p>Start date: {startDate}</p>
        <p>End date:  {endDate}</p>
        <h2 className="text-gray-700">Creator: @{task.creatorUsername}</h2>
        <h2 className="text-gray-800">Assigned to @{task.assigneeUsername}</h2>
        <p>{task.status}</p>
    </div>
  )
}

export default TaskCard