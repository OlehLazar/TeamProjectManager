import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { logout } from "../services/authService";
import Button from "../components/shared/Button";
import Input from "../components/shared/Input";
import { getProfile, deleteProfile, changePassword } from "../services/userService";

const ProfilePage = () => {
  const navigate = useNavigate();
  const [user, setUser] = useState<{ firstName: string; lastName: string; avatar?: string }>(
    { firstName: "", lastName: "", avatar: "" }
  );
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const [passwordData, setPasswordData] = useState({ oldPassword: "", newPassword: "", confirmPassword: "" });
  const [passwordError, setPasswordError] = useState("");
  const [showPasswordForm, setShowPasswordForm] = useState(false);

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

  const handleDelete = async () => {
    await deleteProfile();
    window.dispatchEvent(new Event("authChange"));
    navigate("/login");
  };

  const handlePasswordChange = async (e: React.FormEvent) => {
    e.preventDefault();
    if (passwordData.newPassword !== passwordData.confirmPassword) {
      setPasswordError("New passwords do not match");
      return;
    }
    try {
      await changePassword(passwordData);
      setPasswordData({ oldPassword: "", newPassword: "", confirmPassword: "" });
      setPasswordError("");
      setShowPasswordForm(false);
    } catch (err) {
      console.error("Error changing the password:", err);
      setPasswordError("Failed to change the password");
    }
  };

  if (loading) return <p className="text-center">Loading profile...</p>;
  if (error) return <p className="text-center text-red-500">{error}</p>;

  return (
    <div className="flex flex-col p-6 text-center gap-6 mx-auto w-1/2">
      <h1 className="text-3xl font-bold font-ptSerif">My Profile</h1>
      {user.avatar && <img src={user.avatar} alt="Avatar" className="w-24 h-24 rounded-full mt-4" />}
      <p className="text-xl font-sans">{user.firstName} {user.lastName}</p>
      
      {!showPasswordForm && (
        <Button onClick={() => setShowPasswordForm(true)} width="w-1/4">Change Password</Button>
      )}
      
      {showPasswordForm && (
        <form onSubmit={handlePasswordChange} className="flex flex-col gap-4">
          <Input
            type="password"
            placeholder="Old Password"
            value={passwordData.oldPassword}
            onChange={(e) => setPasswordData({ ...passwordData, oldPassword: e.target.value })}
          />
          <Input
            type="password"
            placeholder="New Password"
            value={passwordData.newPassword}
            onChange={(e) => setPasswordData({ ...passwordData, newPassword: e.target.value })}
          />
          <Input
            type="password"
            placeholder="Confirm New Password"
            value={passwordData.confirmPassword}
            onChange={(e) => setPasswordData({ ...passwordData, confirmPassword: e.target.value })}
          />
          {passwordError && <p className="text-red-500">{passwordError}</p>}
          <Button type="submit" width="w-1/4">Confirm</Button>
        </form>
      )}
      
      <Button onClick={handleLogout} width="w-1/4">Logout</Button>
      <Button onClick={handleDelete} width="w-1/4">Delete profile</Button>
    </div>
  );
};

export default ProfilePage;
