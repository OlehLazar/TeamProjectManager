import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { logout } from "../../services/authService";
import Button from "../../components/ui/Button";
import { getProfile, deleteProfile } from "../../services/userService";
import ChangePasswordForm from "../../components/forms/ChangePasswordForm";
import UpdateProfileForm from "../../components/forms/UpdateProfileForm";
import ErrorMessage from "../../components/ui/ErrorMessage";
import LoadingSpinner from "../../components/ui/LoadingSpinner";

const ProfilePage = () => {
  const navigate = useNavigate();
  const [user, setUser] = useState<{ firstName: string; lastName: string; avatar?: string }>(
    { firstName: "", lastName: "", avatar: "" }
  );
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");
  const [showPasswordForm, setShowPasswordForm] = useState(false);
  const [showUpdateForm, setShowUpdateForm] = useState(false);


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
  
  if (loading) return <LoadingSpinner />;
  if (error) return <ErrorMessage message={error} />;

  return (
    <div className="flex flex-col md:flex-row items-center justify-center min-h-screen p-4 md:p-8 gap-4 md:gap-8">
      {!showPasswordForm && !showUpdateForm && (
        <div className="w-full md:w-auto flex-shrink-0">
          <img 
            src="/src/assets/images/noire.jpg" 
            alt="" 
            className="rounded-3xl p-2 object-contain w-full max-w-[700px] md:h-[70vh]"
          />
        </div>
      )}
      <div className="w-full max-w-[500px] flex flex-col p-4 md:p-6 gap-4 md:gap-6 bg-white rounded-xl shadow-lg">
        <h1 className="text-3xl font-bold font-ptSerif">My Profile</h1>
        {user.avatar && <img src={user.avatar} alt="Avatar" className="w-24 h-24 rounded-full mt-4" />}
        <p className="text-xl font-sans">{user.firstName} {user.lastName}</p>
        
        {!showPasswordForm && (<Button onClick={() => setShowPasswordForm(true)} width="w-full">Change Password</Button>)}
        {showPasswordForm && (<ChangePasswordForm />)}
        
        {!showUpdateForm && (<Button onClick={() => setShowUpdateForm(true)} width="w-full">Update profile</Button>)}
        {showUpdateForm && (<UpdateProfileForm />)}

        <Button onClick={handleLogout} width="w-full">Logout</Button>
        <Button onClick={handleDelete} width="w-full">Delete profile</Button>
      </div>
    </div>
  );
};

export default ProfilePage;
