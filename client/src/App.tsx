import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import DefaultLayout from "./components/shared/DefaultLayout";
import HomePage from "./pages/HomePage";
import LoginPage from "./pages/LoginPage";
import SignupPage from "./pages/SignupPage";
import MyTeamsPage from "./pages/MyTeamsPage";
import MyProjectsPage from "./pages/MyProjectsPage";
import TeamPage from "./pages/TeamPage";
import ProjectPage from "./pages/ProjectPage";
import { exampleTeam } from "./constants/exampleTeam";
import { exampleProjects } from "./constants/exampleProjects";
import { exampleTeams } from "./constants/exampleTeams";
import ProfilePage from "./pages/ProfilePage";
import NotificationsPage from "./pages/NotificationsPage";

const App = () => (
  <Router>
    <Routes>
      <Route element={<DefaultLayout />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/signup" element={<SignupPage />} />
        <Route path="/profile" element={<ProfilePage />} />
        <Route path="/teams" element={<MyTeamsPage teams={exampleTeams} />} />
        <Route path="/teams/:teamId" element={<TeamPage team={exampleTeam} />} />
        <Route path="/projects" element={<MyProjectsPage projects={exampleProjects} />} />
        <Route path="/projects/:projectId" element={<ProjectPage projects={exampleProjects} />} />
        <Route path="/notifications" element={<NotificationsPage />} />
      </Route>
    </Routes>
  </Router>
);

export default App;
