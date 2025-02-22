import { useQuery } from "@tanstack/react-query"
import { ProjectDto } from "../interfaces/dtos/ProjectDto"
import { getProjects } from "../services/projectService";
import ProjectCard from "../components/shared/ProjectCard";

const MyProjectsPage = () => {
    const { data: projects = [], isLoading, error } = useQuery<ProjectDto[]>({
        queryKey: ['projects'],
        queryFn: () => getProjects(),
    });

    return (
        <div className="flex flex-col p-5">
            <h1 className="font-ptSerif font-semibold text-2xl text-center mb-5">
                My projects
            </h1>
            
            {isLoading && <p className="text-center">Loading teams...</p>}
            {error && <p className="text-center text-red-500">Failed to load teams. Please try again later.</p>}

            {!isLoading && !error && projects.length > 0 && (
                <ul className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">
                    {projects.map((project) => (
                        <li key={project.id}>
                            <ProjectCard project={project} />
                        </li>
                    ))}
                </ul>
            )}
        </div>
    )
}

export default MyProjectsPage