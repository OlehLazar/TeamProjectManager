import { ProjectModel } from "./ProjectModel";
import { UserModel } from "./UserModel";

export interface TeamModel {
    id: number;
    name: string;
    description: string;
    leader: UserModel;
    members: UserModel[];
    projects: ProjectModel[];
}