import { useState } from "react";
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
      className={`flex flex-col p-5 gap-3 shadow-sm border rounded-sm cursor-pointer ${
        isRead ? "border-gray-400 bg-white" : "border-red-500 bg-red-100"
      }`}
      onClick={handleToggle}
    >
      <h1 className="font-semibold">{notification.title}</h1>
      
      {isExpanded && (
        <div className="mt-2">
          <p>{notification.content}</p>
          <p className="text-sm text-gray-600">{formattedDate}</p>
        </div>
      )}
    </div>
  );
};

export default NotificationCard;
