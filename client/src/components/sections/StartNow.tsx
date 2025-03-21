import Button from "../ui/Button"

const StartNow = () => {
  return (
    <div className="flex flex-col gap-10 p-2 justify-center text-center mx-auto w-1/2 text-2xl">
      <p className="font-light">
        Improve team communication, increase productivity, and deliver projects on time. 
        Join our growing community of successful teams and unlock your full potential. 
        Get started with us now and discover the difference!
      </p>

      <a href="/login" className="text-3xl"><Button width="w-1/3">START NOW</Button></a>
    </div>
  )
}

export default StartNow