import { useState, useEffect } from "react";
import { navItems as defaultNavItems } from "../../constants";
import { getNotifications } from "../../services/notificationService";

const Navbar = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(!!localStorage.getItem("token"));
  const [hasUnread, setHasUnread] = useState(false);
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  useEffect(() => {
    const handleAuthChange = () => {
      setIsLoggedIn(!!localStorage.getItem("token"));
    };

    const handleResize = () => {
      if (window.innerWidth >= 768) {
        setIsMenuOpen(false);
      }
    };

    window.addEventListener("authChange", handleAuthChange);
    window.addEventListener("resize", handleResize);

    return () => {
      window.removeEventListener("authChange", handleAuthChange);
      window.removeEventListener("resize", handleResize);
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
    <nav className="flex flex-col md:flex-row justify-between items-center max-w-container p-2 text-xl font-semibold font-ptSerif md:mx-6 relative border-b-2 border-[#4e4e4eb6]">
      <div className="flex justify-between w-full md:w-auto items-center">
        <a href="/" className="flex items-center border-r-2 border-[#393939] pr-5">
          <img src="/src/assets/icons/tactic_icon.svg" width={40} alt="tactic" />
          <h1 className="pl-3">Home</h1>
        </a>
        
        {/* Mobile menu button */}
        <button 
          className="md:hidden p-2"
          onClick={() => setIsMenuOpen(!isMenuOpen)}
          aria-label="Toggle menu"
        >
          {isMenuOpen ? (
            <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M6 18L18 6M6 6l12 12" />
            </svg>
          ) : (
            <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M4 6h16M4 12h16M4 18h16" />
            </svg>
          )}
        </button>
      </div>

      <ul className="hidden md:flex flex-1 justify-between pl-5">
        {navItems.map((item, index) => (
          <li key={index}>
            <a href={item.url} className="flex items-center hover:text-gray-300 transition-colors">
              {item.label}
            </a>
          </li>
        ))}
      </ul>

      {isMenuOpen && (
        <ul className="w-full md:hidden flex flex-col space-y-4 mt-4">
          {navItems.map((item, index) => (
            <li key={index}>
              <a 
                href={item.url} 
                className="block py-2 hover:bg-gray-700 px-4 rounded transition-colors"
                onClick={() => setIsMenuOpen(false)}
              >
                {item.label}
              </a>
            </li>
          ))}
        </ul>
      )}
    </nav>
  );
};

export default Navbar;