import { ProjectCardProps } from "../../interfaces/props/ProjectCardProps"
import Button from "./Button"

const ProjectCard: React.FC<ProjectCardProps> = ({ project, onClick }) => {
    return (
        <div className="p-3 border border-gray-400 rounded-lg shadow-[#8787871d] shadow-sm flex flex-col w-full md:w-1/2 lg:w-1/3 gap-3">
            <h3 className="font-semibold text-xl font-ptSerif">{project.name}</h3>
            <p>{project.description}</p>
            <Button width="w-1/3" onClick={onClick}>View project</Button>
        </div>
    )
}

export default ProjectCard