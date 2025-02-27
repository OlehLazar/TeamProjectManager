import { TaskDto } from "./TaskDto";

export interface FullBoardDto {
    id: number;
    name: string;
    description: string;
    createdDate: Date;
    projectId: number;
    tasks: TaskDto [];
}