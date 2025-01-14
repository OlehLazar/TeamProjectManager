import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import DefaultLayout from "./components/shared/DefaultLayout";
import HomePage from "./pages/HomePage";
import LoginPage from "./pages/LoginPage";
import SignupPage from "./pages/SignupPage";
import MyTeamsPage from "./pages/MyTeamsPage";
import TeamPage from "./pages/TeamPage";
import { exampleTeam } from "./constants/exampleTeam";

const App = () => (
  <Router>
    <Routes>
      <Route element={<DefaultLayout />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/signup" element={<SignupPage />} />
        <Route path="/teams" element={<MyTeamsPage />} />
        <Route path="/teams/:teamId" element={<TeamPage team={exampleTeam} />} />
      </Route>
    </Routes>
  </Router>
);

export default App;
