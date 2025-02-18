import { TeamDto } from "../dtos/TeamDto";

export interface TeamCardProps {
    team: TeamDto,
    onClick: () => void,
}