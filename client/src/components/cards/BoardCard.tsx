import { Link } from "react-router-dom"
import { BoardCardProps } from "../../interfaces/props/BoardCardProps"
import { format } from "date-fns";

const BoardCard: React.FC<BoardCardProps> = ({ board }) => {
  const formattedDate = format(board.createdDate, "EEE MMM dd yyyy");

  return (
    <Link to={`/boards/${board.id}`} className="block">
      <div className="p-4 border border-[#15151556] rounded-sm hover:shadow-md hover:shadow-[#989696]">
        <h3 className="font-ptSerif font-semibold text-xl mb-2 text-center">{board.id}</h3>
        <p className="text-gray-600 mb-2">{board.description}</p>
        <p className="text-gray-700">{formattedDate}</p>
      </div>
    </Link>
  )
}

export default BoardCard