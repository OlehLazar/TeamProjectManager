import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { logout } from "../services/authService";
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
      
      <button
        onClick={handleLogout}
        className="mt-6 px-6 py-2 bg-red-500 text-white rounded hover:bg-red-700 transition"
      >
        Logout
      </button>
    </div>
  );
};

export default Profile;
