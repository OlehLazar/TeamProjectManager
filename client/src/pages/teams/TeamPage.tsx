import { useNavigate, useParams } from "react-router-dom";
import { getTeamById, leaveTeam } from "../../services/teamService";
import { useQuery } from "@tanstack/react-query";
import { FullTeamDto } from "../../interfaces/dtos/FullTeamDto";
import { getUser, getProfile } from "../../services/userService";
import { UserDto } from "../../interfaces/dtos/UserDto";
import Button from "../../components/ui/Button";
import { useState } from "react";
import AddMemberForm from "../../components/forms/AddMemberForm";
import { deleteTeam } from "../../services/teamService";
import axios from "axios";
import ProjectCard from "../../components/cards/ProjectCard";
import ErrorMessage from "../../components/ui/ErrorMessage";
import LoadingSpinner from "../../components/ui/LoadingSpinner";

const TeamPage = () => {
  const params = useParams();
  const teamId = Number(params.teamId);
  const navigate = useNavigate();

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

  const handleCreateProject = () => {
    navigate(`/teams/${teamId}/create`);
  }

  if (isLoading) return <LoadingSpinner />;
  if (isError) return <ErrorMessage message="Error fetching team data." />;

  return (
    <div className="p-10 flex flex-col gap-5">
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

      {leader?.userName === currentUser?.userName && (<div className="w-1/2 object-scale-down"><Button width="w-1/4 md:w-1/2 sm:w-full" onClick={handleDelete} >Delete the team</Button></div>)}
      {deleteError && <ErrorMessage message={deleteError} />}

      <div className="w-1/2"><Button width="w-1/4" onClick={handleLeave}>Leave</Button></div>
      {leaveError && <ErrorMessage message={leaveError} />}

      <h2 className="text-center font-bold font-ptSerif text-2xl">Projects</h2>
      <div className="w-1/2"><Button width="w-1/4" onClick={handleCreateProject}>Create a project</Button></div>
      <ul className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">
        {data!.projects.map((project) => (
          <li key={project.id}>
            <ProjectCard project={project} />
          </li>
        ))}
      </ul>

      <h2 className="text-center font-bold font-ptSerif text-2xl">Members</h2>
      {!showAddMemberForm && leader?.userName === currentUser?.userName && (<div className="w-1/2"><Button width="w-1/4" onClick={() => setShowAddMemberForm(true)}>Add a member</Button></div>)}
      {showAddMemberForm && (<AddMemberForm />)}
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