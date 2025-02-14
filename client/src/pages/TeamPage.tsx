/* eslint-disable @typescript-eslint/no-explicit-any */
import { useEffect, useState } from "react";
import { TeamModel } from "../interfaces/models/TeamModel";
import { useParams } from "react-router-dom";
import { getTeamById } from "../services/teamService";
import { getUser } from "../services/userService";
import { UserModel } from "../interfaces/models/UserModel";
import { ProjectModel } from "../interfaces/models/ProjectModel";

const TeamPage = () => {
  const params = useParams();
  const teamId = Number(params.teamId);
  
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [team, setTeam] = useState<TeamModel>();

  useEffect(() => {
    const fetchTeamData = async () => {
      setLoading(true);
      setError(null);

      try {
        const response = await getTeamById(teamId);
        console.log('API Response:', response);
        const teamModel = convertFullTeamDtoToModel(response.data);
        setTeam(await teamModel);
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

    </div>
  );
};


const convertFullTeamDtoToModel = async (dto: any): Promise<TeamModel> => {
  if (!dto) {
    throw new Error("Team data is undefined");
  }

  const leader = await getUser(dto.leaderUsername);
  if (!leader) {
    throw new Error(`Leader user not found for username: ${dto.leaderUsername}`);
  }

  return {
    id: dto.id,
    name: dto.name,
    description: dto.description,
    leader: leader,
    members: dto.members?.map(convertUserDtoToModel) ?? [],
    projects: dto.projects?.map(convertProjectDtoToModel) ?? [],
  };
};



const convertUserDtoToModel = (dto: any): UserModel => ({
  firstName: dto.FirstName,
  lastName: dto.LastName,
  userName: dto.UserName,
  avatar: dto.Avatar
});

const convertProjectDtoToModel = (dto: any): ProjectModel => ({
  id: dto.Id,
  name: dto.Name,
  description: dto.Description,
  boards: null // Initialize as null until boards are loaded separately
});

export default TeamPage;