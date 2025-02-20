

const ProjectPage = () => {
  
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