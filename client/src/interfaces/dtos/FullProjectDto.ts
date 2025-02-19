import { BoardDto } from "./BoardDto";

export interface FullProjectDto {
    id: number;
    name: string;
    description: string;
    teamId: number;
    boards: BoardDto[];
}