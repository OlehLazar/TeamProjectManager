export interface TaskDto {
    id: number;
    name: string;
    description: string;
    startDate: Date;
    endDate: Date;
    boardId: number;
    creatorUsername: string;
    assigneeUsername: string;
    status: boolean;
}