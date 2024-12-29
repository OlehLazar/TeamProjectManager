import { navItems } from "../../constants"

const Navbar = () => {
  return (
    <div className="flex justify-between items-center max-w-container p-2 text-xl md:mx-6 relative">
      <a href="/" className="flex items-center border-r-2 border-[#6e6e6e] pr-5">
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