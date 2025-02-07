import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { logout } from "../services/authService";
import Button from "../components/shared/Button";

const Profile = () => {
  const navigate = useNavigate();

  useEffect(() => {
    const token = localStorage.getItem("token");

    if (!token) {
      navigate("/login");
    }
  }, [navigate]);

  const handleLogout = async () => {
    await logout();
    navigate("/login");
  };

  return (
    <div className="flex flex-col items-center p-6">
      <h1 className="text-2xl font-bold">My Profile</h1>
      
      <Button
        onClick={handleLogout}
      >
        Logout
      </Button>
    </div>
  );
};

export default Profile;
