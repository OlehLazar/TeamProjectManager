import { useParams } from "react-router-dom";
import { ProjectModel } from "../interfaces/models/ProjectModel";

const ProjectPage: React.FC<{ projects: ProjectModel[] }> = ({ projects }) => {
    const { projectId } = useParams<{ projectId: string }>();
    const project = projects.find((p) => p.id === Number(projectId));
  
    if (!project) {
        return (
            <div className="flex flex-col items-center justify-center min-h-screen">
                <h1 className="text-3xl font-semibold">Project Not Found</h1>
                <p className="text-gray-600 mt-3">The project you are looking for does not exist.</p>
            </div>
        );
    }
  
    return (
        <div className="p-5">
            <h1 className="font-ptSerif font-semibold text-3xl mb-3">{project.name}</h1>
            <p className="text-gray-700 text-lg mb-5">{project.description}</p>
    
            <h2 className="font-semibold text-2xl mb-3">Boards</h2>
            {project.boards && project.boards.length > 0 ? (
                <ul className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
                    {project.boards?.map((board) => (
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
                    {project.boards === null ? "Boards information is unavailable." : "No boards available for this project."}
                </p>
            )}
        </div>
    );
};
  
export default ProjectPage;