import { useState } from "react";
import { FaBell, FaChevronUp, FaChevronDown } from "react-icons/fa";
import { format } from "date-fns";
import { NotificationCardProps } from "../../interfaces/props/NotificationCardProps";
import { readNotification } from "../../services/notificationService";

const NotificationCard: React.FC<NotificationCardProps> = ({ notification }) => {
  const [isExpanded, setIsExpanded] = useState(false);
  const [isRead, setIsRead] = useState(notification.isRead);
  
  const formattedDate = format(notification.createdAt, "EEE MMM dd yyyy");

  const handleToggle = async () => {
    if (!isRead) {
      try {
        await readNotification(notification.id);
        setIsRead(true);
      } catch (error) {
        console.error("Failed to mark notification as read:", error);
      }
    }
    setIsExpanded(!isExpanded);
  };

  return (
    <div 
      className={`flex flex-col p-5 gap-3 shadow-sm border rounded-2xl mx-auto cursor-pointer ${
        isRead ? "border-gray-400 bg-white" : "border-red-500 bg-red-100"
      }`}
      onClick={handleToggle}
    >
      <div className="flex items-center justify-between">
        <div className="flex items-center gap-3">
          <FaBell className={`w-5 h-5 ${isRead ? "text-gray-400" : "text-blue-500"}`} />
          <h1 className="font-semibold text-lg">{notification.title}</h1>
        </div>
        {isExpanded ? <FaChevronUp className="w-5 h-5 text-gray-600" /> : <FaChevronDown className="w-5 h-5 text-gray-600" />}
      </div>
      
      {isExpanded && (
        <div className="mt-2">
          <p className="text-gray-700">{notification.content}</p>
          <p className="font-semibold text-gray-800 text-sm mt-2">{formattedDate}</p>
        </div>
      )}
    </div>
  );
};

export default NotificationCard;