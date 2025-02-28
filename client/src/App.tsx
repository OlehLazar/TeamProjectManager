import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import DefaultLayout from "./components/layout/DefaultLayout";
import HomePage from "./pages/home/HomePage";
import LoginPage from "./pages/auth/LoginPage";
import SignupPage from "./pages/auth/SignupPage";
import MyTeamsPage from "./pages/teams/MyTeamsPage";
import MyProjectsPage from "./pages/projects/MyProjectsPage";
import TeamPage from "./pages/teams/TeamPage";
import ProjectPage from "./pages/projects/ProjectPage";
import ProfilePage from "./pages/profile/ProfilePage";
import NotificationsPage from "./pages/notifications/NotificationsPage";
import CreateTeamPage from "./pages/teams/CreateTeamPage";
import { QueryClientProvider, QueryClient } from "@tanstack/react-query";
import CreateProjectPage from "./pages/projects/CreateProjectPage";
import BoardPage from "./pages/boards/BoardPage";
import CreateTaskPage from "./pages/tasks/CreateTaskPage";

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
          <Route path="/teams/:teamId/create" element={<CreateProjectPage />} />
          <Route path="/teams/create" element={<CreateTeamPage />} />
          <Route path="/projects" element={<MyProjectsPage />} />
          <Route path="/projects/:projectId" element={<ProjectPage />} />
          <Route path="/boards/:boardId" element={<BoardPage />} />
          <Route path="/boards/:boardId/createTask" element={<CreateTaskPage />} />
          <Route path="/notifications" element={<NotificationsPage />} />
        </Route>
      </Routes>
    </Router>
  </QueryClientProvider>
);

export default App;
