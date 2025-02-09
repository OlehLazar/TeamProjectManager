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
  const [errorMessage, setErrorMessage] = useState("");

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    
    if (formData.password !== formData.repeatPassword) {
      alert("Passwords do not match!");
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
          const messages = Object.values(validationErrors).flat().join(" ");
          setErrorMessage(messages);
        } else {
          setErrorMessage(error.response?.data?.title || "An error occurred.");
        }
      } else if (error instanceof Error) {
        setErrorMessage(error.message);
      } else {
        setErrorMessage("An unexpected error occurred.");
      }
    }
  };

  return (
    <form onSubmit={handleSubmit} className="flex flex-col items-center gap-4">
      <Input name="firstName" placeholder="First Name" width="w-1/3" value={formData.firstName} onChange={handleChange} />
      <Input name="lastName" placeholder="Last Name" width="w-1/3" value={formData.lastName} onChange={handleChange} />
      <Input name="userName" placeholder="Nickname" width="w-1/3" value={formData.userName} onChange={handleChange} />
      <Input name="password" type="password" placeholder="Password" width="w-1/3" value={formData.password} onChange={handleChange} />
      <Input name="repeatPassword" type="password" placeholder="Repeat Password" width="w-1/3" value={formData.repeatPassword} onChange={handleChange} />
      <Button width="w-1/6" type="submit">Sign up</Button>
      {errorMessage && <p className="text-red-500 mt-2">{errorMessage}</p>}
    </form>
  );
};

export default SignupForm;
