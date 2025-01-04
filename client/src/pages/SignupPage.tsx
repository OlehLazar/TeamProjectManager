import Input from "../components/shared/Input"
import Button from "../components/shared/Button"

const SignupPage = () => {
  return (
    <div className="pt-10 pb-10 flex flex-col justify-center text-center gap-5 mx-auto w-1/2">
        <h1 className="text-2xl font-bold text font-ptSerif">Enter your data:</h1>
        <Input name="first_name" placeholder="first name" width="w-1/3" />
        <Input name="last_name" placeholder="last name" width="w-1/3" />
        <Input name="nickname" placeholder="nickname" width="w-1/3" />
        <Input name="email" placeholder="email" width="w-1/3" />
        <Input name="password" placeholder="password" width="w-1/3" />
        <Input name="repeat_password" placeholder="repeat password" width="w-1/3" />
        <Button width="w-1/6">Sign up</Button>
    </div>
  )
}

export default SignupPage