import { useQuery } from "@tanstack/react-query"
import { ProjectDto } from "../../interfaces/dtos/ProjectDto";
import { getProjects } from "../../services/projectService";
import ProjectCard from "../../components/cards/ProjectCard";
import ErrorMessage from "../../components/ui/ErrorMessage";

const MyProjectsPage = () => {
    const isLoggedIn = !!localStorage.getItem("token");

    const { data: projects = [], isLoading, error } = useQuery<ProjectDto[]>({
        queryKey: ['projects'],
        queryFn: () => getProjects(),
        enabled: isLoggedIn,
    });

    return (
        <div className="flex flex-col p-10">
            <h1 className="font-ptSerif font-semibold text-2xl text-center mb-5">
                My projects
            </h1>
            
            {!isLoggedIn && (
                <p className="text-center text-red-500">
                    You need to be logged in to view your projects. Please <a href="/login" className="text-blue-500 underline">log in</a>.
                </p>
            )}

            {isLoggedIn && isLoading && <p className="text-center">Loading projects...</p>}
            {isLoggedIn && error && <ErrorMessage message="Failed to load projects. Please try again later." />}

            {isLoggedIn && !isLoading && !error && projects.length > 0 && (
                <ul className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">
                    {projects.map((project) => (
                        <li key={project.id}>
                            <ProjectCard project={project} />
                        </li>
                    ))}
                </ul>
            )}

            {isLoggedIn && !isLoading && !error && projects.length === 0 && (
                <p className="text-center">No projects found.</p>
            )}
        </div>
    )
}

export default MyProjectsPage