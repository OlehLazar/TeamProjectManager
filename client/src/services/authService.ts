import api from "./api";

interface LoginData {
  userName: string;
  password: string;
}

interface RegisterData {
  firstName: string;
  lastName: string;
  userName: string;
  password: string;
}

export const login = async (data: LoginData) => {
  const response = await api.post('/auth/login', data);
  localStorage.setItem('token', response.data.token);
  return response.data;
};

export const signup = async (data: RegisterData) => {
  const response = await api.post('/auth/register', data);
  return response.data;
};

export const logout = async () => {
  const token = localStorage.getItem('token');
  if (token) {
    await api.post('/auth/logout', {}, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    localStorage.removeItem('token');
  }
};
