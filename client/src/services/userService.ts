import { UserDto } from "../interfaces/dtos/UserDto";
import api from "./api";

export const getProfile = async () => {
  const response = await api.get("/user/profile", {
    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
  });
  return response.data;
};

export const getNotifications = async () => {
  const response = await api.get("/user/notifications", {
    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
  });
  return response.data;
};

export const readNotification = async (id: number) => {
  const response = await api.put(`/notification/${id}`);
  return response.data;
}

export const getUser = async (userName: string): Promise<UserDto> => {
  const response = await api.get<UserDto>(`/user/${userName}`);
  return response.data;
};

export const updateProfile = async (userData: { firstName: string; lastName: string; avatar?: string }) => {
  await api.put("/user", userData, {
    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
  });
};

export const changePassword = async (passwordData: { oldPassword: string, newPassword: string}) => {
  await api.put("/user/change-password", passwordData, {
    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
  });
};

export const deleteProfile = async () => {
  await api.delete("/user", {
    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
  });
};
