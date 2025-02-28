import api from "./api";

interface CreateTaskData {
    name: string;
    description: string;
    startDate: Date;
    endDate: Date;
    boardId: number;
    creatorUsername: string;
    assigneeUsername: string;
}

export const getTasks = async () => {
    const response = await api.get('/task');
    return Array.isArray(response.data) ? response.data : [];
}

export const createTask = async (data: CreateTaskData) => {
    const response = await api.post('/task', data);
    return response.data;
}

export const completeTask = async (id: number) => {
    const response = await api.put('/task', id);
    return response.data;
}