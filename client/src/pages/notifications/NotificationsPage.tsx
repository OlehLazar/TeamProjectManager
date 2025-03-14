import { useQuery } from "@tanstack/react-query";
import { getNotifications } from "../../services/notificationService";
import { NotificationDto } from "../../interfaces/dtos/NotificationDto";
import ErrorMessage from "../../components/ui/ErrorMessage";
import NotificationCard from "../../components/cards/NotificationCard";

const NotificationsPage = () => {
  const isLoggedIn = !!localStorage.getItem("token");

  const { data: notifications = [], isLoading, error } = useQuery<NotificationDto[]>({
    queryKey: ['notifications'],
    queryFn: () => getNotifications(),
    enabled: isLoggedIn,
  });
  
  return (
    <div className="p-10 flex flex-col gap-5">
        <h1 className="font-ptSerif font-semibold text-3xl text-center">Notifications</h1>

        {!isLoggedIn && <ErrorMessage message="You need to be logged in t view your notifications" />}
        {isLoggedIn && isLoading && <p>Loading notifications...</p>}
        {isLoggedIn && error && <ErrorMessage message="Failed to load notifications. Please try again later." />}

        {isLoggedIn && !isLoading && !error && notifications.length > 0 && (
            <ul className="grid grid-cols-1 gap-5">
                {notifications.map((notification) => (
                    <li key={notification.id} className="border p-5">
                        <NotificationCard notification={notification} />
                    </li>
                ))}
            </ul>
        )}

        {isLoggedIn && !isLoading && !error && notifications.length === 0 && (
            <p>No notifications found.</p>
        )}
    </div>
  )
}

export default NotificationsPage