export interface NotificationDto {
    id: number;
    title: string;
    content: string;
    createdAt: Date;
    isRead: boolean;
    username: string;
}