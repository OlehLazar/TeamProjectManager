import api from "./api";

interface CreateNotificationData {
    title: string;
    content: string;
    username: string;
}

export const getNotifications = async () => {
    const response = await api.get('/notification');
    return Array.isArray(response.data) ? response.data : [];
}

export const notify = async (data: CreateNotificationData) => {
    const response = await api.post('/notification/notify', data);
    return Array.isArray(response.data) ? response.data : [];
}