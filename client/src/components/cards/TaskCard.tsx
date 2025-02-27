import { TaskCardProps } from "../../interfaces/props/TaskCardProps"

const TaskCard: React.FC<TaskCardProps> = ({ task }) => {
  return (
    <div className="flex flex-col gap-5 p-3 border border-gray-400 rounded-sm shadow-sm shadow-[#11111160]">
        <h1 className="font-ptSerif font-semibold text-xl">{task.name}</h1>
        <p>{task.description}</p>
    </div>
  )
}

export default TaskCard