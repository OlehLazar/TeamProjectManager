import { useState } from "react";
import Input from "../shared/Input";
import Button from "../shared/Button";
import { register } from "../../services/authService";
import axios from "axios";

const SignupForm: React.FC = () => {
  const [formData, setFormData] = useState({
    firstName: "",
    lastName: "",
    userName: "",
    password: "",
    repeatPassword: "",
  });
  
  const [fieldErrors, setFieldErrors] = useState<Record<string, string[]>>({});

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    
    const newErrors: Record<string, string[]> = {};

    if (formData.password !== formData.repeatPassword) {
      newErrors.RepeatPassword = ["Passwords do not match"];
    }

    if (Object.keys(newErrors).length > 0) {
      setFieldErrors(newErrors);
      return;
    }

    try {
      await register(formData);
      window.location.href = "/login";
    } catch (error: unknown) {
      console.error("Signup failed:", error);
    
      if (axios.isAxiosError(error)) {
        const validationErrors = error.response?.data?.errors;
    
        if (validationErrors) {
          setFieldErrors(validationErrors);
        } else {
          setFieldErrors({ general: [error.response?.data?.title || "An error occurred."] });
        }
      } else if (error instanceof Error) {
        setFieldErrors({ general: [error.message] });
      } else {
        setFieldErrors({ general: ["An unexpected error occurred."] });
      }
    }
  };

  return (
    <form onSubmit={handleSubmit} className="flex flex-col items-center gap-4">
      <Input name="firstName" placeholder="First Name" width="w-1/3" value={formData.firstName} onChange={handleChange} />
      {fieldErrors.FirstName && fieldErrors.FirstName.map((err, i) => (
        <p key={i} className="text-red-500 text-sm">{err}</p>
      ))}

      <Input name="lastName" placeholder="Last Name" width="w-1/3" value={formData.lastName} onChange={handleChange} />
      {fieldErrors.LastName && fieldErrors.LastName.map((err, i) => (
        <p key={i} className="text-red-500 text-sm">{err}</p>
      ))}

      <Input name="userName" placeholder="Username" width="w-1/3" value={formData.userName} onChange={handleChange} />
      {fieldErrors.UserName && fieldErrors.UserName.map((err, i) => (
        <p key={i} className="text-red-500 text-sm">{err}</p>
      ))}

      <Input name="password" type="password" placeholder="Password" width="w-1/3" value={formData.password} onChange={handleChange} />
      {fieldErrors.Password && fieldErrors.Password.map((err, i) => (
        <p key={i} className="text-red-500 text-sm">{err}</p>
      ))}

      <Input name="repeatPassword" type="password" placeholder="Repeat Password" width="w-1/3" value={formData.repeatPassword} onChange={handleChange} />
      {fieldErrors.RepeatPassword && fieldErrors.RepeatPassword.map((err, i) => (
        <p key={i} className="text-red-500 text-sm">{err}</p>
      ))}

      <Button width="w-1/6" type="submit">Sign up</Button>
    </form>
  );
};

export default SignupForm;
