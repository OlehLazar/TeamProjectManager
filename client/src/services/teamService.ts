import axios from "axios";

interface CreateTeamData {
    name: string;
    description: string;
    leaderUsername: string;
};

export const getTeams = async () => {
    const response = await axios.get('/team');
    return Array.isArray(response.data) ? response.data : [];
};
  
export const getTeamById = async (id: number) => {
    const response = await axios.get(`/team/${id}`);
    return response.data;
};

export const createTeam = async (data: CreateTeamData) => {
    const response = await axios.post('/team', data);
    return response.data;
};

export const deleteTeam = async (id: number) => {
    const response = await axios.delete(`/team/${id}`);
    return response.data;
};

export const leaveTeam = async (teamId: number) => {
    const response = await axios.post(`/team/${teamId}/leave`);
    return response.data;
};

export const addMember = async (teamId: number, userName: string) => {
    const response = await axios.post(`/team/${teamId}/add-member`, userName, {
      headers: { 'Content-Type': 'application/json' },
    });
    return response.data;
};