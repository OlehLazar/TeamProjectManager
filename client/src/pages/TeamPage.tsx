import { useParams } from "react-router-dom";
import { getTeamById, leaveTeam } from "../services/teamService";
import { useQuery } from "@tanstack/react-query";
import { FullTeamDto } from "../interfaces/dtos/FullTeamDto";
import { getUser, getProfile } from "../services/userService";
import { UserDto } from "../interfaces/dtos/UserDto";
import Button from "../components/shared/Button";
import { useState } from "react";
import AddMemberForm from "../components/teamPage/AddMemberForm";
import { deleteTeam } from "../services/teamService";
import axios from "axios";

const TeamPage = () => {
  const params = useParams();
  const teamId = Number(params.teamId);

  const [showAddMemberForm, setShowAddMemberForm] = useState(false);
  const [deleteError, setDeleteError] = useState<string | null>(null);
  const [leaveError, setLeaveError] = useState<string | null>(null);

  const { data, isLoading, isError } = useQuery<FullTeamDto>({
    queryKey: ['team', teamId],
    queryFn: () => getTeamById(teamId),
  });

  const { data: leader } = useQuery<UserDto>({
    queryKey: ['user', data?.leaderUsername],
    queryFn: () => getUser(data!.leaderUsername),
    enabled: !!data,
  });

  const { data: currentUser } = useQuery<UserDto>({
    queryKey: ["currentUser"],
    queryFn: () => getProfile(),
  });

  const handleDelete = async () => {
    try {
      await deleteTeam(teamId);
      window.location.href = "/teams";
    } catch (error) {
      console.error("Deletition failed:", error);
      if (axios.isAxiosError(error)) {
        const errors = error.response?.data?.errors;
        setDeleteError(errors);
      }
    }
  }

  const handleLeave = async () => {
    try {
      await leaveTeam(Number(params.teamId));
      window.location.href = "/teams";
    } catch (error) {
      console.error("Leaving failed:", error);
      if (axios.isAxiosError(error)) {
        const errors = error.response?.data;
        setLeaveError(errors);
      }
    }
  }

  if (isLoading) return <div className="flex text-center">Loading...</div>;
  if (isError) return <div className="flex text-center">Error fetching team data</div>;

  return (
    <div className="pt-5 pb-5 pl-10 pr-10 flex flex-col gap-5">
      <h1 className="font-ptSerif font-semibold text-3xl">{data!.name}</h1>
      <p className="font-openSans text-lg">{data!.description}</p>

      {leader && (
        <div className="flex items-center gap-3 pt-3">
          <h2 className="font-semibold font-ptSerif text-xl">
            {leader.firstName} {leader.lastName}
          </h2>
          <p className="text-sm text-gray-500">@{leader.userName}</p>
        </div>
      )}

      {!showAddMemberForm && leader?.userName === currentUser?.userName && (<div className="w-1/2"><Button width="w-1/4" onClick={() => setShowAddMemberForm(true)}>Add a member</Button></div>)}
      {showAddMemberForm && (<AddMemberForm />)}

      {leader?.userName === currentUser?.userName && (<div className="w-1/2"><Button width="w-1/4" onClick={handleDelete} >Delete the team</Button></div>)}
      {deleteError && (<div className="text-red-500 mb-4">{deleteError}</div>)}

      <div className="w-1/2"><Button width="w-1/4" onClick={handleLeave}>Leave</Button></div>
      {leaveError && (<div className="text-red-500 mb-4">{leaveError}</div>)}
      
      <h2 className="text-center font-bold font-ptSerif text-xl">Projects</h2>
      <ul className="flex flex-col gap-5 pt-5 pb-5">
        {data!.projects.map((project) => (
          <li key={project.id}>
            <div className="p-3 border border-gray-300 rounded-lg shadow-black shadow-sm flex flex-col w-full md:w-1/2 lg:w-1/3">
              <h3 className="font-semibold text-xl font-ptSerif">{project.name}</h3>
              <p>{project.description}</p>
            </div>
          </li>
        ))}
      </ul>

      <h2 className="text-center font-bold font-ptSerif text-xl">Members</h2>
      <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5 pt-5 pb-5">
        {data!.members.map((member) => (
          <li key={member.userName}>
            <div className="p-3 border border-gray-400 rounded-lg flex flex-col items-center">
              <h3 className="font-semibold text-xl font-ptSerif">
                {member.firstName} {member.lastName}
              </h3>
              <p className="text-sm text-gray-500">@{member.userName}</p>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default TeamPage;