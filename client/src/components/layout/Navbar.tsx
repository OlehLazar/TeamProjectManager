import { useState, useEffect } from "react";
import { navItems as defaultNavItems } from "../../constants";
import { getNotifications } from "../../services/notificationService";

const Navbar = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(!!localStorage.getItem("token"));
  const [hasUnread, setHasUnread] = useState(false);

  useEffect(() => {
    const handleAuthChange = () => {
      setIsLoggedIn(!!localStorage.getItem("token"));
    };

    window.addEventListener("authChange", handleAuthChange);

    return () => {
      window.removeEventListener("authChange", handleAuthChange);
    };
  }, []);

  useEffect(() => {
    if (isLoggedIn) {
      const fetchNotifications = async () => {
        try {
          const notifications = await getNotifications();
          setHasUnread(notifications.some(n => !n.isRead));
        } catch (error) {
          console.error("Failed to fetch notifications:", error);
        }
      };

      fetchNotifications();
    }
  }, [isLoggedIn]);

  const navItems = isLoggedIn
    ? defaultNavItems.map((item) => {
        if (item.label === "Log in") {
          return { ...item, label: "My profile", url: "/profile" };
        }
        if (item.label === "Notifications") {
          return {
            ...item,
            label: hasUnread ? "Notifications 🔴" : "Notifications",
          };
        }
        return item;
      })
    : defaultNavItems;

  return (
    <div className="flex justify-between items-center max-w-container p-2 
    text-xl font-semibold font-ptSerif md:mx-6 relative 
    border-b-2 border-[#4e4e4eb6]">
      <a href="/" className="flex items-center border-r-2 border-[#393939] pr-5">
        <img src="/src/assets/icons/tactic_icon.svg" width={40} alt="tactic" />
        <h1 className="pl-3">Home</h1>
      </a>
      <ul className="flex-1 flex justify-between pl-5">
        {navItems.map((item, index) => (
          <li key={index}>
            <a href={item.url} className="flex items-center">
              {item.label}
            </a>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Navbar;
