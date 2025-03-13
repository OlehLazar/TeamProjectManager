import { NotificationCardProps } from "../../interfaces/props/NotificationCardProps"

const NotificationCard: React.FC<NotificationCardProps> = ({ notification }) => {
  return (
    <div className="flex flex-col p-5 gap-5 shadow-sm border border-gray-400 rounded-sm">
      <h1>{notification.title}</h1>
      <p>{notification.content}</p>
      <p>{notification.username}</p>
    </div>
  )
}

export default NotificationCard