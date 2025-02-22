import Paragraph from "../ui/Paragraph";
import { aboutContent } from "../../constants/aboutContent";

const AboutUs = () => {
  return (
    <div className="pt-10 pb-5 pl-40 pr-40 flex flex-col text-xl">
      <h1 className="pb-10 text-3xl font-bold text-center font-ptSerif">About us</h1>
      {aboutContent.map(({ heading, text, image, reverse }, index) => (
        <div
          key={index}
          className={`flex gap-10 pb-10 ${reverse ? "flex-row-reverse" : ""}`}
        >
          <Paragraph heading={heading} text={text} />
          <img
            src={image.src}
            alt={image.alt}
            className={`${image.className} hidden md:block`}
          />
        </div>
      ))}
    </div>
  );
};

export default AboutUs