import { TeamModel } from "../interfaces/models/TeamModel";
export const exampleTeam: TeamModel = {
    id: 1,
    name: "Development Team",
    description: "We are responsible for building and maintaining the platform.",
    leader: {
      id: 10,
      firstName: "Alice",
      lastName: "Johnson",
      userName: "alicej",
    },
    members: [
      { id: 11, firstName: "Bob", lastName: "Smith", userName: "bobsmith" },
      { id: 12, firstName: "Charlie", lastName: "Brown", userName: "charlieb" },
    ],
    projects: [
      { id: 101, name: "Project Alpha", description: "Initial phase of the project." },
      { id: 102, name: "Project Beta", description: "Advanced stage of the project." },
    ],
};
  