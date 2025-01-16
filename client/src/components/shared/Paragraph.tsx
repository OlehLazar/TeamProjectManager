import { ParagraphProps } from "../../interfaces/props/ParagraphProps"

const Paragraph: React.FC<ParagraphProps> = ({ heading, text}) => {
  return (
    <div className="flex flex-col">
        <h1 className="text-center text-2xl font-ptSerif font-semibold pb-3">{heading}</h1>
        <p className="font-openSans">{text}</p>
    </div>
  )
}

export default Paragraph