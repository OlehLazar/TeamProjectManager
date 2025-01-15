import Button from "../components/shared/Button"
import Input from "../components/shared/Input"
import TeamCard from "../components/myTeamsPage/TeamCard"
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { MyTeamsPageProps } from "../interfaces/props/MyTeamsPageProps";

const MyTeamsPage: React.FC<MyTeamsPageProps> = ({ teams }) => {
  const [searchTerm, setSearchTerm] = useState("");
  const navigate = useNavigate();

  const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(e.target.value);
  };

  const handleCreateTeam = () => {
    // Navigate to a team creation page or open a modal
    console.log("Redirect to team creation page or show modal.");
  };

  const handleTeamClick = (teamId: number) => {
    navigate(`/teams/${teamId}`);
  };

  return (
    <div className="pt-5 pb-5 flex flex-col justify-between items-center">
      <div className="flex w-1/2 mx-auto p-5">
        <Input
          name="team_search"
          placeholder="Search for a team"
          width="w-1/2"
          onChange={handleSearchChange}
        />
        <Button width="w-1/4" onClick={handleCreateTeam}>
          Create a team
        </Button>
      </div>
      <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5 w-4/5 mx-auto pt-5 pb-5">
        {teams.length > 0 ? (
          teams.map((team) => (
            <li key={team.id}>
              <TeamCard
                team={team}
                onClick={() => handleTeamClick(team.id)}
              />
            </li>
          ))
        ) : (
          <p className="col-span-full text-gray-600 text-center">
            No teams found matching "{searchTerm}"
          </p>
        )}
      </ul>
    </div>
  );
};

export default MyTeamsPage;