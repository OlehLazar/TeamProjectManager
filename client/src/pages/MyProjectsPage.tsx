import { MyProjectsPageProps } from "../interfaces/props/MyProjectsPageProps"

const MyProjectsPage: React.FC<MyProjectsPageProps> = ({ projects }) => {
  return (
    <div className="flex flex-col p-5">
        <h1 className="font-ptSerif font-semibold text-2xl text-center mb-5">
            My projects
        </h1>
        
        {projects.length > 0 ? (
            <ul className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">
                {projects.map((project) => (
                    <li key={project.id}>
                        <div className="p-4 border border-gray-300 rounded-lg shadow-lg hover:shadow-xl transition-shadow">
                            <h2 className="font-ptSerif font-semibold text-xl mb-2">
                                {project.name}
                            </h2>
                            <p className="text-gray-600">{project.description}</p>
                        </div>
                    </li>
                ))}
            </ul>
        ) : (
            <p className="text-center text-gray-600">You are not part of any projects yet.</p>
        )}
    </div>
  )
}

export default MyProjectsPage