import { ParagraphProps } from "../../interfaces/ParagraphProps"

const Paragraph: React.FC<ParagraphProps> = ({ heading, text}) => {
  return (
    <div className="flex flex-col fonr-openSans">
        <h1 className="text-center text-2xl font-semibold pb-3">{heading}</h1>
        <p>{text}</p>
    </div>
  )
}

export default Paragraph