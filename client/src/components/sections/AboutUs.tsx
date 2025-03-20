import { aboutContent } from "../../constants/aboutContent";

const AboutUs = () => {
  return (
    <div className="p-10 flex flex-col text-xl">
      <h1 className="pb-10 text-4xl font-bold text-center font-ptSerif">About us</h1>
      {aboutContent.map(({ heading, text, image, reverse }, index) => (
        <div
          key={index}
          className={`flex gap-10 ${reverse ? "flex-row-reverse" : ""}`}
        >
          <div className="flex flex-col gap-5">
            <h1 className="font-ptSerif font-semibold text-4xl">{heading}</h1>
            <p className="w-2/3 text-2xl font-light">{text}</p>
          </div>
          
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