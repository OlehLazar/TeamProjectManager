import { useQuery } from "@tanstack/react-query";
import { useParams } from "react-router-dom"
import { FullBoardDto } from "../../interfaces/dtos/FullBoardDto";
import { getBoardById } from "../../services/boardService";
import Button from "../../components/ui/Button";

const BoardPage = () => {
    const params = useParams();
    const boardId = Number(params.boardId);

    const { data, isLoading, isError } = useQuery<FullBoardDto>({
        queryKey: ['board', boardId],
        queryFn: () => getBoardById(boardId),
    });

    const handleCreateTaskClick = async () => {
        window.location.href = `/boards/${boardId}/createTask`;
    }

    if (isLoading) return <div className="flex text-center">Loading...</div>;
    if (isError) return <div className="flex text-center">Error fetching board data</div>

    return (
        <div className="flex flex-col gap-5 pt-5 pb-5 pl-10 pr-10">
            <h1 className="font-ptSerif font-semibold text-2xl text-center">{data!.name}</h1>
            <p className="text-lg">{data!.description}</p>
            <div><Button onClick={handleCreateTaskClick} width="w-1/6">Create a task</Button></div>

            <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5 pt-5 pb-5">

            </ul>
        </div>
    )
}

export default BoardPage