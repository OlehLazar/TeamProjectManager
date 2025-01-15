import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import DefaultLayout from "./components/shared/DefaultLayout";
import HomePage from "./pages/HomePage";
import LoginPage from "./pages/LoginPage";
import SignupPage from "./pages/SignupPage";
import MyTeamsPage from "./pages/MyTeamsPage";
import MyProjectsPage from "./pages/MyProjectsPage";
import TeamPage from "./pages/TeamPage";
import { exampleTeam } from "./constants/exampleTeam";
import { exampleProjects } from "./constants/exampleProjects";

const App = () => (
  <Router>
    <Routes>
      <Route element={<DefaultLayout />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/signup" element={<SignupPage />} />
        <Route path="/teams" element={<MyTeamsPage />} />
        <Route path="/teams/:teamId" element={<TeamPage team={exampleTeam} />} />
        <Route path="/projects" element={<MyProjectsPage projects={exampleProjects} />} />
      </Route>
    </Routes>
  </Router>
);

export default App;
