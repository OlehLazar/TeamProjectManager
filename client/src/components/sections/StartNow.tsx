import Button from "../ui/Button"

const StartNow = () => {
  return (
    <div className="flex flex-col gap-8 px-4 py-10 text-center mx-auto w-full sm:w-5/6 md:w-2/3 lg:w-1/2 text-base sm:text-lg md:text-xl lg:text-2xl">
      <p className="font-light">
        Improve team communication, increase productivity, and deliver projects on time. 
        Join our growing community of successful teams and unlock your full potential. 
        Get started with us now and discover the difference!
      </p>

      <a href="/login" className="text-3xl"><Button width="w-full sm:w-1/2 md:w-1/3">START NOW</Button></a>
    </div>
  )
}

export default StartNow