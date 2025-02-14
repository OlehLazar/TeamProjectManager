import { useEffect, useState } from "react";
import { TeamModel } from "../interfaces/models/TeamModel";
import { useParams } from "react-router-dom";
import { getTeamById } from "../services/teamService";
import { getUser } from "../services/userService";

const TeamPage = () => {
  const params = useParams();
  const teamId = Number(params.teamId);
  
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [team, setTeam] = useState<TeamModel | null>(null);

  useEffect(() => {
    const fetchTeamData = async () => {
      try {
        if (!teamId) {
          throw new Error("Invalid team ID");
        }
        
        const response = await getTeamById(teamId);
        const transformedTeam = transformFullTeamDto(response);
        setTeam(transformedTeam);
      } catch (err) {
        setError(err instanceof Error ? err.message : "An unexpected error occurred");
      } finally {
        setLoading(false);
      }
    };

    fetchTeamData();
  }, [teamId]);

  if (loading) return <div>Loading team information...</div>;
  if (error) return (
    <div className="text-red-500">
      {error}
    </div>
  );
  if (!team) return <div>Team not found</div>;

  return (
    <div className="pt-5 pb-5 pl-10 pr-10 flex flex-col gap-3">
      <h1 className="font-ptSerif font-semibold text-3xl">{team.name}</h1>
      <p className="font-openSans text-lg">{team.description}</p>
      
      {/* Leader Section */}
      <div className="flex items-center gap-3 pt-3">
        <div>
          <h2 className="font-semibold font-ptSerif text-xl">
            {team.leader.firstName} {team.leader.lastName}
          </h2>
          <p className="text-sm text-gray-500">@{team.leader.userName}</p>
        </div>
      </div>

      {/* Projects Section */}
      <div className="mt-5">
        <h2 className="text-center font-bold font-ptSerif text-xl">Projects</h2>
        {team.projects?.length > 0 ? (
          <ul className="flex flex-col gap-5 pt-5 pb-5">
            {team.projects.map((project) => (
              <li key={project.id}>
                <div className="p-3 border border-gray-300 rounded-lg shadow-black shadow-sm flex flex-col w-full md:w-1/2 lg:w-1/3">
                  <h3 className="font-semibold text-xl font-ptSerif">{project.name}</h3>
                  <p>{project.description}</p>
                </div>
              </li>
            ))}
          </ul>
        ) : (
          <p className="text-center text-gray-500">No projects available.</p>
        )}
      </div>

      {/* Members Section */}
      <div className="mt-5">
        <h2 className="text-center font-bold font-ptSerif text-xl">Members</h2>
        {team.members?.length > 0 ? (
          <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5 pt-5 pb-5">
            {team.members.map((member) => (
              <li key={member.id}>
                <div className="p-3 border border-gray-400 rounded-lg flex flex-col items-center">
                  {member.avatar && (
                    <img
                      src={member.avatar}
                      alt={`${member.firstName} ${member.lastName}`}
                      className="w-16 h-16 rounded-full mb-3"
                    />
                  )}
                  <h3 className="font-semibold text-xl font-ptSerif">
                    {member.firstName} {member.lastName}
                  </h3>
                  <p className="text-sm text-gray-500">@{member.userName}</p>
                </div>
              </li>
            ))}
          </ul>
        ) : (
          <p className="text-center text-gray-500">No members available.</p>
        )}
      </div>
    </div>
  );
};

// Helper function to transform FullTeamDto to TeamModel
const transformFullTeamDto = (fullTeam: FullTeamDto): TeamModel => ({
  id: fullTeam.Id,
  name: fullTeam.Name,
  description: fullTeam.Description,
  leader: getUser(fullTeam.LeaderUsername),
});

interface FullTeamDto {
    Id: number;
    Name: string;
    Description: string;
    LeaderUsername: string;

};

export default TeamPage;