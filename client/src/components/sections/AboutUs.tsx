import { aboutContent } from "../../constants/aboutContent";

const AboutUs = () => {
  return (
    <div className="px-4 py-10 flex flex-col gap-10 text-base sm:text-lg md:text-xl lg:text-2xl">
      <h1 className="pb-4 text-4xl font-bold text-center font-ptSerif">About us</h1>
      {aboutContent.map(({ heading, text, image, reverse }, index) => (
        <div
          key={index}
          className={`flex flex-col md:flex-row gap-6 md:gap-10 ${reverse ? "md:flex-row-reverse" : ""}`}
        >
          <div className="flex flex-col gap-5">
            <h1 className="font-ptSerif font-semibold text-4xl">{heading}</h1>
            <p className="w-full sm:w-5/6 md:w-2/3">{text}</p>
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