import { Link } from "react-router-dom"
import { BoardCardProps } from "../../interfaces/props/BoardCardProps"

const BoardCard: React.FC<BoardCardProps> = ({ board }) => {
  return (
    <Link to={`/boards/${board.id}`} className="block">
      <div className="p-4 border-[#5a595956] rounded-sm shadow-lg shadow-black hover:shadow-xl">
        <h3 className="font-ptSerif font-semibold text-xl mb-2 text-center">{board.id}</h3>
        <p className="text-gray-600 mb-2">{board.description}</p>
        <p className="text-gray-700">{board.createdDate.toDateString()}</p>
      </div>
    </Link>
  )
}

export default BoardCard