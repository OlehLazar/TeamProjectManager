import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import DefaultLayout from "./components/shared/DefaultLayout";
import HomePage from "./pages/HomePage";
import LoginPage from "./pages/LoginPage";
import SignupPage from "./pages/SignupPage";
import MyTeamsPage from "./pages/MyTeamsPage";
import MyProjectsPage from "./pages/MyProjectsPage";
import TeamPage from "./pages/TeamPage";
import ProjectPage from "./pages/ProjectPage";
import ProfilePage from "./pages/ProfilePage";
import NotificationsPage from "./pages/NotificationsPage";
import CreateTeamPage from "./pages/CreateTeamPage";
import { QueryClientProvider, QueryClient } from "@tanstack/react-query";

const queryClient = new QueryClient();

const App = () => (
  <QueryClientProvider client={queryClient}>
    <Router>
      <Routes>
        <Route element={<DefaultLayout />}>
          <Route path="/" element={<HomePage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/signup" element={<SignupPage />} />
          <Route path="/profile" element={<ProfilePage />} />
          <Route path="/teams" element={<MyTeamsPage />} />
          <Route path="/teams/:teamId" element={<TeamPage />} />
          <Route path="/teams/create" element={<CreateTeamPage />} />
          <Route path="/projects" element={<MyProjectsPage />} />
          <Route path="/projects/:projectId" element={<ProjectPage />} />
          <Route path="/notifications" element={<NotificationsPage />} />
        </Route>
      </Routes>
    </Router>
  </QueryClientProvider>
);

export default App;
