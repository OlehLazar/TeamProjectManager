import { ProjectDto } from "./ProjectDto";
import { UserDto } from "./UserDto";

export interface FullTeamDto {
    id: number;
    name: string;
    description: string;
    leaderUsername: string;
    members: UserDto[];
    projects: ProjectDto[];
}