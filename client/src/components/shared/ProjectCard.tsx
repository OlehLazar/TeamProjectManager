import { Link } from "react-router-dom"
import { ProjectCardProps } from "../../interfaces/props/ProjectCardProps"

const ProjectCard: React.FC<ProjectCardProps> = ({ project }) => {
    return (
        <Link to={`/projects/${project.id}`} className="block">
            <div className="p-4 border border-gray-300 rounded-lg shadow-lg hover:shadow-xl transition-shadow">
                <h3 className="font-ptSerif font-semibold text-xl mb-2">{project.name}</h3>
                <p className="text-gray-600">{project.description}</p>
            </div>
        </Link>
    )
}

export default ProjectCard