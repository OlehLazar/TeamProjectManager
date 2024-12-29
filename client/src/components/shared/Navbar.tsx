const Navbar = () => {
  return (
    <div className="flex justify-between items-center max-w-container p-2 text-xl md:mx-6 relative">
      <a href="/" className="flex items-center border-r-2 border-[#11111150] pr-5">
        <img src="/src/assets/icons/tactic_icon.svg" width={40} alt="tactuc" className="" />
        <h1 className="pl-3">Home</h1>
      </a>
    </div>
  )
}

export default Navbar