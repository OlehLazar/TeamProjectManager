import Button from "../components/ui/Button"
import Input from "../components/ui/Input"
import TeamCard from "../components/cards/TeamCard"
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { getTeams } from "../services/teamService";
import { TeamDto } from "../interfaces/dtos/TeamDto";
import { useQuery } from "@tanstack/react-query";

const MyTeamsPage = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const navigate = useNavigate();

  const { data: teams = [], isLoading, error } = useQuery<TeamDto[]>({
    queryKey: ['teams'],
    queryFn: () => getTeams(),
  });

  const filteredTeams = searchTerm.trim() === ""
  ? teams
  : teams.filter((team) =>
      team.name.toLowerCase().includes(searchTerm.toLowerCase())
    );
  
  const handleCreateTeam = () => {
    navigate("/teams/create");
  };

  const handleTeamClick = (teamId: number) => {
    navigate(`/teams/${teamId}`);
  };

  return (
    <div className="pt-5 pb-5 flex flex-col justify-between items-center">
      <div className="flex w-1/2 mx-auto p-5">
        <Input
          placeholder="Search for a team"
          width="w-1/2"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <Button width="w-1/4" onClick={handleCreateTeam}>Create a team</Button>
      </div>

      {isLoading && <p className="text-center">Loading teams...</p>}
      {error && <p className="text-center text-red-500">Failed to load teams. Please try again later.</p>}

      {!isLoading && !error && (
        <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5 w-4/5 mx-auto pt-5 pb-5">
          {filteredTeams.length > 0 ? (
            filteredTeams.map((team) => (
              <li key={team.id}>
                <TeamCard
                  team={team}
                  onClick={() => handleTeamClick(team.id)}
                />
              </li>
            ))
          ) : (
            <p className="col-span-full text-gray-600 text-center">
              {searchTerm ? `No teams found matching "${searchTerm}"` : "No teams available."}
            </p>
          )}
        </ul>
      )}
    </div>
  );
};

export default MyTeamsPage;