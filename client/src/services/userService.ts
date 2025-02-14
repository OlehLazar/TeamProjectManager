import { UserModel } from "../interfaces/models/UserModel";
import api from "./api";

export const getProfile = async () => {
  const response = await api.get("/user/profile", {
    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
  });
  return response.data;
};

export const getUser = async (userName: string): Promise<UserModel | null> => {
  try {
    const response = await api.get<UserModel>(`/user/${userName}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching user:', error);
    return null;
  }
};

export const updateProfile = async (userData: { firstName: string; lastName: string; avatar?: string }) => {
  await api.put("/user", userData, {
    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
  });
};

export const changePassword = async (passwordData: { oldPassword: string, newPassword: string, confirmPassword: string }) => {
  await api.put("/user/change-password", passwordData, {
    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
  });
};

export const deleteProfile = async () => {
  await api.delete("/user", {
    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
  });
};
