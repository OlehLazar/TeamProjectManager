import SignupForm from "../../components/forms/SignupForm"

const SignupPage = () => {
  return (
    <div className="pt-10 pb-10 flex flex-col justify-center text-center gap-5 mx-auto w-1/2">
        <h1 className="text-2xl font-bold text font-ptSerif">Enter your data:</h1>
        <SignupForm />
    </div>
  )
}

export default SignupPage