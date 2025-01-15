import { TeamModel } from "../models/TeamModel";

export interface TeamCardProps {
    team: TeamModel,
    onClick: () => void,
}