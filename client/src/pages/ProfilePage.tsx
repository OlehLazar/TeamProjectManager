import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { logout } from "../services/authService";
import Button from "../components/shared/Button";
import { getProfile } from "../services/userService";

const ProfilePage = () => {
  const navigate = useNavigate();
  const [user, setUser] = useState<{ firstName: string; lastName: string; avatar?: string }>({
    firstName: "",
    lastName: "",
    avatar: "",
  });
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token) {
      navigate("/login");
      return;
    }

    const fetchProfile = async () => {
      try {
        const data = await getProfile();
        setUser(data);
      } catch (err) {
        console.error("Error fetching profile:", err);
        setError("Failed to load profile");
      } finally {
        setLoading(false);
      }
    };

    fetchProfile();
  }, [navigate]);

  const handleLogout = async () => {
    await logout();
    window.dispatchEvent(new Event("authChange"));
    navigate("/login");
  };

  if (loading) return <p className="text-center">Loading profile...</p>;
  if (error) return <p className="text-center text-red-500">{error}</p>;

  return (
    <div className="flex flex-col p-6 text-center gap-6 mx-auto w-1/2">
      <h1 className="text-3xl font-bold font-ptSerif">My Profile</h1>
      {user.avatar && <img src={user.avatar} alt="Avatar" className="w-24 h-24 rounded-full mt-4" />}
      <p className="text-lg mt-2">{user.firstName} {user.lastName}</p>
      <Button onClick={handleLogout} width="w-1/4">Logout</Button>
    </div>
  );
};

export default ProfilePage;
