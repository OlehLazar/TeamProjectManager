import { ErrorMessageProps } from "../../interfaces/props/ErrorMessageProps"

const ErrorMessage: React.FC<ErrorMessageProps> = ({ message }) => {
  return (
    <span className="text-md text-red-500">
        {message}
    </span>
  )
}

export default ErrorMessage