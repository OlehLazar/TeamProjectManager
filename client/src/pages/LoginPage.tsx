import { login } from "../services/authService";
import LoginForm from "../components/loginPage/LoginForm"

const LoginPage = () => {
  const handleLogin = async (username: string, password: string) => {
    try {
      await login({ userName: username, password });
      window.location.href = "/"; // Redirect on success
    } catch (error) {
      console.error("Login failed:", error);
      alert("Invalid credentials. Please try again.");
    }
  };

  return (
    <div className="pt-10 pb-10 flex flex-col justify-center text-center gap-5 mx-auto w-1/2">
      <h1 className="text-2xl font-bold text font-ptSerif">Enter your data:</h1>
      <LoginForm onSubmit={handleLogin} />
      <p>
        Don't have an account yet? <a href="/signup" className="font-semibold hover:font-bold">Sign up now</a>
      </p>
    </div>
  )
}

export default LoginPage