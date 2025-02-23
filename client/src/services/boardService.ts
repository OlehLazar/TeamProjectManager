import api from "./api";

interface CreateBoardData {
    name: string;
    description: string;
    projectId: number;
}

export const getBoards = async () => {
    const response = await api.get('/board');
    return Array.isArray(response.data) ? response.data : [];
}

export const getBoardById = async (id: number) => {
    const response = await api.get(`/board/${id}`);
    return response.data;
}

export const createBoard = async (data: CreateBoardData) => {
    const response = await api.post('/board', data)
    return response.data;
}