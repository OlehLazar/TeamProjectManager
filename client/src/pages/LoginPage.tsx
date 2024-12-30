import Input from "../components/shared/Input"
import Button from "../components/shared/Button"

const LoginPage = () => {
  return (
    <div className="pt-10 pb-10 flex flex-col justify-center text-center gap-5 mx-auto w-1/2">
      <h1 className="text-2xl font-bold text">Enter your data:</h1>
      <Input name="nickname" placeholder="nickname" width="w-1/3" />
      <Input name="password" placeholder="password" width="w-1/3" />
      <Button width="w-1/6">Log in</Button>
      <p>Don't have an account yet? <a href="/signup" className="font-semibold">Sign up now</a></p>
    </div>
  )
}

export default LoginPage