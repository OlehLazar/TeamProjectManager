import { navItems } from "../../constants"

const Navbar = () => {
  return (
    <div className="flex justify-between items-center max-w-container p-2 
    text-xl font-semibold font-ptSerif md:mx-6 relative 
    border-b-2 border-[#4e4e4eb6]">
      <a href="/" className="flex items-center border-r-2 border-[#393939] pr-5">
        <img src="/src/assets/icons/tactic_icon.svg" width={40} alt="tactuc" className="" />
        <h1 className="pl-3">Home</h1>
      </a>
      <ul className="flex-1 flex justify-between pl-5">
        {navItems.map((item, index) => (
          <li key={index}>
          <a href={item.url} className="flex items-center">
            {item.label}
          </a>
          </li>
        ))}
      </ul>
    </div>
  )
}

export default Navbar