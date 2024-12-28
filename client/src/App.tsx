import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import DefaultLayout from "./components/shared/DefaultLayout";
import HomePage from "./pages/HomePage"

const App = () => (
  <Router>
    <Routes>
      <Route element={<DefaultLayout />}>
        <Route path="/" element={<HomePage />} />
      </Route>
    </Routes>
  </Router>
);

export default App;
