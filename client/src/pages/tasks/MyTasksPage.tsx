import { useQuery } from "@tanstack/react-query";
import { TaskDto } from "../../interfaces/dtos/TaskDto";
import { getTasks } from "../../services/taskService";
import ErrorMessage from "../../components/ui/ErrorMessage";
import TaskCard from "../../components/cards/TaskCard";
import LoadingSpinner from "../../components/ui/LoadingSpinner";

const MyTasksPage = () => {
    const isLoggedIn = !!localStorage.getItem("token");

    const { data: tasks = [], isLoading, error } = useQuery<TaskDto[]>({
        queryKey: ['tasks'],
        queryFn: () => getTasks(),
        enabled: isLoggedIn,
    });
    
    const completedTasks = tasks.filter(task => task.status);
    const uncompletedTasks = tasks.filter(task => !task.status);

    return (
        <div className="flex flex-col p-10 gap-10">
            {!isLoggedIn &&
                <p className="text-center text-red-500">
                    You need to be logged in to view your tasks. Please <a href="/login" className="text-blue-500 underline">log in</a>.
                </p>
            }

            {isLoggedIn && isLoading && <LoadingSpinner />}

            {isLoggedIn && error && <ErrorMessage message="Failed to load tasks. Please try again later." />}

            {isLoggedIn && !isLoading && !error && tasks.length > 0 && (
                <>
                    <h2 className="font-ptSerif text-2xl text-center">Uncompleted Tasks</h2>
                    <ul className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">
                        {uncompletedTasks.map((task) => (
                            <li key={task.id}>
                                <TaskCard task={task} />
                            </li>
                        ))}
                    </ul>

                    <h2 className="font-ptSerif text-2xl text-center">Completed Tasks</h2>
                    <ul className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5 bg-[#61656628] p-2 b b-blue rounded-xl">
                        {completedTasks.map((task) => (
                            <li key={task.id}>
                                <TaskCard task={task} />
                            </li>
                        ))}
                    </ul>
                </>
            )}
        </div>
    )
}

export default MyTasksPage;