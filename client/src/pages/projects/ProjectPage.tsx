import { useQuery } from "@tanstack/react-query";
import { useParams } from "react-router-dom";
import { FullProjectDto } from "../../interfaces/dtos/FullProjectDto";
import { getProjectById } from "../../services/projectService";
import { BoardDto } from "../../interfaces/dtos/BoardDto";
import Button from "../../components/ui/Button";
import { useState } from "react";
import CreateBoardForm from "../../components/forms/CreateBoardForm";


const ProjectPage = () => {
    const params = useParams();
    const projectId = Number(params.projectId);

    const [showCreateBoardForm, setShowCreateBoardForm] = useState(false);

    const { data, isLoading, isError } = useQuery<FullProjectDto>({
        queryKey: ['project', projectId],
        queryFn: () => getProjectById(projectId),
    });

    if (isLoading) return <div className="flex text-center">Loading...</div>;
    if (isError) return <div className="flex text-center">Error fetching project data</div>;

    return (
        <div className="flex flex-col p-5 gap-5">
            <h1 className="font-ptSerif font-semibold text-3xl mb-3">{data!.name}</h1>
            <p className="text-gray-700 text-lg mb-5">{data!.description}</p>

            {!showCreateBoardForm && <div><Button width="w-1/6" onClick={() => setShowCreateBoardForm(true)}>Create a new board</Button></div>}
            {showCreateBoardForm && <CreateBoardForm projectId={projectId} />}

            <h2 className="font-semibold text-2xl mb-3">Boards</h2>
            {data!.boards && data!.boards.length > 0 ? (
                <ul className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
                    {data!.boards?.map((board: BoardDto) => (
                        <li
                            key={board.id}
                            className="p-4 border border-gray-300 rounded-lg shadow hover:shadow-md transition-shadow"
                        >
                            <h3 className="font-semibold text-xl">{board.name}</h3>
                        </li>
                    ))}
                </ul>
            ) : (
                <p className="text-gray-600">
                    {data!.boards === null ? "Boards information is unavailable." : "No boards available for this project."}
                </p>
            )}
        </div>
    );
};
  
export default ProjectPage;