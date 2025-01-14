import { InputProps } from "../../interfaces/props/InputProps"

const Input: React.FC<InputProps> = ({onChange, placeholder, name, width}) => {
  return (
    <input 
      onChange={onChange}
      placeholder={placeholder}
      name={name}
      className={`pb-2 pt-2 pr-3 pl-3 focus: outline-none border-b border-[#1111116a] mx-auto ${width}`}
    />
  )
}

export default Input