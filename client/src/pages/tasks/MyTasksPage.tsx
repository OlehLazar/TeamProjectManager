import { useQuery } from "@tanstack/react-query";
import { TaskDto } from "../../interfaces/dtos/TaskDto";
import { getTasks } from "../../services/taskService";
import ErrorMessage from "../../components/ui/ErrorMessage";
import TaskCard from "../../components/cards/TaskCard";

const MyTasksPage = () => {
    const isLoggedIn = !!localStorage.getItem("token");

    const { data: tasks = [], isLoading, error } = useQuery<TaskDto[]>({
        queryKey: ['tasks'],
        queryFn: () => getTasks(),
        enabled: isLoggedIn,
    });

    return (
        <div className="flex flex-col p-10 gap-5">
            <h1 className="font-ptSerif text-3xl text-center">My tasks</h1>

            {!isLoggedIn && (<ErrorMessage message="You need to be logged in to view your tasks" />)}
            {isLoggedIn && isLoading && <p className="text-center">Loading tasks...</p>}
            {isLoggedIn && error && <ErrorMessage message="Failed to load tasks. Please try again later." />}
            {isLoggedIn && !isLoading && !error && tasks.length > 0 && (
                <ul className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">
                    {tasks.map((task) => (
                        <li key={task.id}>
                            <TaskCard task={task} />
                        </li>
                    ))}
                </ul>
            )}
        </div>
    )
}

export default MyTasksPage