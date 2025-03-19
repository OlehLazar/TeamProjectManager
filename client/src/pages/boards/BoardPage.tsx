import { useQuery } from "@tanstack/react-query";
import { useParams } from "react-router-dom";
import { FullBoardDto } from "../../interfaces/dtos/FullBoardDto";
import { getBoardById } from "../../services/boardService";
import Button from "../../components/ui/Button";
import TaskCard from "../../components/cards/TaskCard";

const BoardPage = () => {
  const params = useParams();
  const boardId = Number(params.boardId);

  const { data, isLoading, isError } = useQuery<FullBoardDto>({
    queryKey: ["board", boardId],
    queryFn: () => getBoardById(boardId),
  });

  const handleCreateTaskClick = async () => {
    window.location.href = `/boards/${boardId}/createTask`;
  };

  if (isLoading) return <div className="flex text-center">Loading...</div>;
  if (isError) return <div className="flex text-center">Error fetching board data</div>;

  const completedTasks = data!.tasks.filter((task) => task.status);
  const uncompletedTasks = data!.tasks.filter((task) => !task.status);

  return (
    <div className="flex flex-col gap-7 pt-5 pb-5 pl-10 pr-10">
      <h1 className="font-ptSerif font-semibold text-2xl text-center">{data!.name}</h1>
      <p className="text-lg text-center">{data!.description}</p>
      <div className="text-center">
        <Button onClick={handleCreateTaskClick} width="w-1/6">
          Create a task
        </Button>
      </div>

      <section className="bg-blue-50 p-5 rounded-lg border border-blue-200">
        <h2 className="font-ptSerif font-semibold text-2xl mb-5 text-center text-blue-800">
          Uncompleted Tasks
        </h2>
        {uncompletedTasks.length > 0 ? (
          <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5">
            {uncompletedTasks.map((task) => (
              <li
                key={task.id}
                className="bg-white shadow-md rounded-md p-5 border border-blue-100 hover:shadow-lg transition-shadow duration-200"
              >
                <TaskCard task={task} />
              </li>
            ))}
          </ul>
        ) : (
          <p className="text-gray-600">No uncompleted tasks available for this board.</p>
        )}
      </section>

      <section>
        <h2 className="font-ptSerif font-semibold text-2xl text-center">Completed Tasks</h2>
        {completedTasks.length > 0 ? (
          <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5 pt-5 pb-5">
            {completedTasks.map((task) => (
              <li key={task.id} className="bg-white shadow-md rounded-md p-5">
                <TaskCard task={task} />
              </li>
            ))}
          </ul>
        ) : (
          <p className="text-gray-600">No completed tasks available for this board.</p>
        )}
      </section>
    </div>
  );
};

export default BoardPage;