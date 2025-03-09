import api from "./api";

interface CreateProjectData {
    name: string;
    description: string;
    teamId: number;
}

export const getProjects = async () => {
    const response = await api.get('/project');
    return Array.isArray(response.data) ? response.data : [];
}

export const getProjectById = async (id: number) => {
    const response = await api.get(`/project/${id}`);
    return response.data;
}

export const createProject = async (data: CreateProjectData) => {
    const response = await api.post('/project', data)
    return response.data;
}

export const deleteProject = async (id: number) => {
    const response = await api.delete(`/project/${id}`);
    return response.data;
}
