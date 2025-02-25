import LoginForm from "../../components/forms/LoginForm"

const LoginPage = () => {
  return (
    <div className="pt-10 pb-10 flex flex-col justify-center text-center gap-5 mx-auto w-1/2">
      <LoginForm />
      <p>
        Don't have an account yet? <a href="/signup" className="font-semibold hover:font-bold">Sign up now</a>
      </p>
    </div>
  )
}

export default LoginPage