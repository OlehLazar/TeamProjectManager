import { ErrorMessageProps } from "../../interfaces/props/ErrorMessageProps"

const ErrorMessage: React.FC<ErrorMessageProps> = ({ message }) => {
  return (
    <span className="text-md text-red-500 font-semibold">
        {message}
    </span>
  )
}

export default ErrorMessage