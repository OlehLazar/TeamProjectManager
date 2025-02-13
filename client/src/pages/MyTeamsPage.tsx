import Button from "../components/shared/Button"
import Input from "../components/shared/Input"
import TeamCard from "../components/myTeamsPage/TeamCard"
import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import { TeamModel } from "../interfaces/models/TeamModel";
import { getTeams } from "../services/teamService";

const MyTeamsPage = () => {
  const [teams, setTeams] = useState<TeamModel[]>([]);
  const [filteredTeams, setFilteredTeams] = useState<TeamModel[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const [searchTerm, setSearchTerm] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    const fetchTeams = async () => {
      try {
        const data = await getTeams();
        setTeams(data);
        setFilteredTeams(data);
      } catch (err) {
        console.error("Failed to load teams:", err);
        setError("Failed to load teams. Please try again later.");
      } finally {
        setLoading(false);
      }
    };
    fetchTeams();
  }, []);

  useEffect(() => {
    if (searchTerm.trim() === "") {
      setFilteredTeams(teams);
    } else {
      const filtered = teams.filter((team) =>
        team.name.toLowerCase().includes(searchTerm.toLowerCase())
      );
      setFilteredTeams(filtered);
    }
  }, [searchTerm, teams]);


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
          name="team_search"
          placeholder="Search for a team"
          width="w-1/2"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <Button width="w-1/4" onClick={handleCreateTeam}>Create a team</Button>
      </div>

      {loading && <p className="text-center">Loading teams...</p>}
      
      {error && <p className="text-center text-red-500">{error}</p>}

      {!loading && !error && (
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