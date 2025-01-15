import { BoardModel } from './BoardModel';

export interface ProjectModel {
    id: number;
    name: string;
    description: string;
    boards?: BoardModel[] | null;
}