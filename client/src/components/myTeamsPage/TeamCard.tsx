import { TeamCardProps } from "../../interfaces/props/TeamCardProps"
import Button from "../shared/Button"

const TeamCard: React.FC<TeamCardProps> = ({ team, onClick }) => {
  return (
    <div className="p-3 border border-gray-300 rounded-lg shadow-black shadow-sm flex flex-col gap-5">
        <h1 className="font-semibold text-xl font-ptSerif">{team.name}</h1>
        <p>{team.description}</p>
        <Button width="w-1/3" onClick={onClick}>View team</Button>
    </div>
  )
}

export default TeamCard