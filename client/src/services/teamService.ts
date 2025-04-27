import { FullTeamDto } from "../interfaces/dtos/FullTeamDto";
import api from "./api";

interface CreateTeamData {
    name: string;
    description: string;
};

export const getTeams = async () => {
    const response = await api.get('/team');
    return Array.isArray(response.data) ? response.data : [];
};

export const getTeamById = async (id: number): Promise<FullTeamDto> => {
    const response = await api.get(`/team/${id}`);
    return response.data;
};

export const createTeam = async (data: CreateTeamData) => {
    const response = await api.post('/team', data);
    return response.data;
};

export const deleteTeam = async (id: number) => {
    const response = await api.delete(`/team/${id}`);
    return response.data;
};

export const leaveTeam = async (teamId: number) => {
    const response = await api.post(`/team/${teamId}/leave`, teamId);
    return response.data;
};

export const addMember = async (teamId: number, userName: string) => {
    const response = await api.post(`/team/${teamId}/add-member`, userName, {
      headers: { 'Content-Type': 'application/json' },
    });

    return response.data;
};

export const getMembers = async (boardId: number) => {
    const response = await api.get(`/team/${boardId}/members`);
    return Array.isArray(response.data) ? response.data : [];
}