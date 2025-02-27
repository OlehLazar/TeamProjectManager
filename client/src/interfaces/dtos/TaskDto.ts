export interface TaskDto {
    id: number;
    name: string;
    description: string;
    startDate: Date;
    endDate: Date;
    boardId: number;
    creatorId: string;
    assigneeId: string;
    status: boolean;
}