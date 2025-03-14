import { TeamCardProps } from "../../interfaces/props/TeamCardProps"
import Button from "../ui/Button"

const TeamCard: React.FC<TeamCardProps> = ({ team, onClick }) => {
  return (
    <div className="p-3 border border-gray-400 rounded-lg shadow-[#4141s4142] shadow-sm flex flex-col gap-5 hover:shadow-lg hover:border-gray-500">
        <h1 className="font-semibold text-xl font-ptSerif">{team.name}</h1>
        <p>{team.description}</p>
        <Button width="w-1/3" onClick={onClick}>View team</Button>
    </div>
  )
}

export default TeamCard