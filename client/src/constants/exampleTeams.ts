import { TeamModel } from "../interfaces/models/TeamModel";

export const exampleTeams: TeamModel[] = [
    { id: 1, name: "Alpha Team", description: "Team Alpha is focused on innovation.", 
        leader: { id: 1, firstName: "John", lastName: "Doe", userName: "@johnd"  }, members: null, projects: null },
    { id: 2, name: "Beta Squad", description: "Beta Squad works on community projects.", 
        leader: { id: 1, firstName: "John", lastName: "Doe", userName: "@johnd"  }, members: null, projects: null },
    { id: 3, name: "Gamma Group", description: "Gamma Group handles testing and QA.", 
        leader: { id: 1, firstName: "John", lastName: "Doe", userName: "@johnd"  }, members: null, projects: null},
    { id: 4, name: "Delta Force", description: "Delta Force specializes in logistics.", 
        leader: { id: 1, firstName: "John", lastName: "Doe", userName: "@johnd"  }, members: null, projects: null },
];