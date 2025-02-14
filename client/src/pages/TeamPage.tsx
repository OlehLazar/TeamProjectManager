import { useEffect, useState } from "react";
import { TeamModel } from "../interfaces/models/TeamModel";
import { TeamPageProps } from "../interfaces/props/TeamPageProps"
import { useParams } from "react-router-dom";
import { getTeamById } from "../services/teamService";

const TeamPage: React.FC<TeamPageProps> = ({ team }) => {
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const [currentTeam, setCurrentTeam] = useState<TeamModel | null>(null);
    const params = useParams();
    const teamId = params.teamId;
    
    useEffect(() => {
        const fetchTeamData = async () => {
          if (!team && teamId) {
            try {
              const data = await getTeamById(Number(teamId));
              setCurrentTeam(data);
            } catch (err) {
              console.error("Failed to load team:", err);
              setError("Failed to load team information.");
            }
          } else {
            setCurrentTeam(team ?? null);
          }
          setLoading(false);
        };
        fetchTeamData();
    }, [team, teamId]);

    if (loading) return <div>Loading team information...</div>;
    if (error) return <div className="text-red-500">{error}</div>;

    const displayTeam = currentTeam ?? team;
    if (!displayTeam) return <div>Team not found</div>;

    return (
        <div className="pt-5 pb-5 pl-10 pr-10 flex flex-col gap-3">
            <h1 className="font-ptSerif font-semibold text-3xl">{displayTeam.name}</h1>
            <p className="font-openSans text-lg">{displayTeam.description}</p>

            <div className="flex items-center gap-3 pt-3">
                <div>
                    <h2 className="font-semibold font-ptSerif text-xl">
                        {displayTeam.leader.firstName} {displayTeam.leader.lastName}
                    </h2>
                    <p className="text-sm text-gray-500">@{displayTeam.leader.userName}</p>
                </div>
            </div>

            {/*<h2 className="text-center font-bold font-ptSerif text-xl">Projects</h2>
            {displayTeam.projects.length > 0 ? (
                <ul className="flex flex-col gap-5 pt-5 pb-5">
                {displayTeam.projects.map((project) => (
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

            <h2 className="text-center font-bold font-ptSerif text-xl">Members</h2>
            {displayTeam.members.length > 0 ? (
                <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5 pt-5 pb-5">
                    {displayTeam.members.map((member) => (
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
            )}*/}
        </div>
    )
}

export default TeamPage