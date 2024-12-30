import Input from "../components/shared/Input"
import Button from "../components/shared/Button"

const LoginPage = () => {
  return (
    <div className="p-10 flex flex-col justify-center text-center gap-10">
      <Input />
      <Button width="w-1/6">Log in</Button>
    </div>
  )
}

export default LoginPage