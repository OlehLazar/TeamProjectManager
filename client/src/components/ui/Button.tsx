import { ButtonProps } from "../../interfaces/props/ButtonProps"

const Button: React.FC<ButtonProps> = ({
  type, 
  onClick, 
  children, 
  width, 
  textColor = "text-white", 
  bgColor = "bg-[#111111e6]"
}) => {
  return (
    <button 
      type={type} 
      onClick={onClick}
      className={`inline-block leading-normal 
        ${bgColor} ${textColor} font-ptSerif p-3 
        rounded-2xl hover:text-gray-300 
        active:font-semibold mx-auto ${width}`}
    >
      {children}
    </button>
  )
}

export default Button