import api from "./api";
import { notify } from "./notificationService";

interface CreateTaskData {
    name: string;
    description: string;
    startDate: Date;
    endDate: Date;
    boardId: number;
    assigneeUsername: string;
}

export const getTasks = async () => {
    const response = await api.get('/task');
    return Array.isArray(response.data) ? response.data : [];
}

export const createTask = async (data: CreateTaskData) => {
    const response = await api.post('/task', data);
    
    await notify({
        title: "New Task Assigned",
        content: `You have been assigned a new task: "${data.name}".`,
        username: data.assigneeUsername
    });

    return response.data;
}

export const completeTask = async (id: number) => {
    const response = await api.put(`/task?taskId=${id}`);
    return response.data;
}