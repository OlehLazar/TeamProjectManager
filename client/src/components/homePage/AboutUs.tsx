import Paragraph from "../shared/Paragraph"

const AboutUs = () => {
  return (
    <div className="pt-10 pb-5 pl-40 pr-40 flex flex-col text-xl">
      <h1 className="pb-10 text-2xl font-semibold text-center">About us</h1>
      <div className="flex gap-5 pb-10">
        <Paragraph
        heading="heading"
        text="Lorem ipsum, dolor sit amet consectetur adipisicing elit. Id aliquam provident consequatur veritatis tenetur illo voluptatibus! Culpa voluptatum nam, voluptatem aspernatur amet eum. Repellendus fugiat velit perspiciatis repudiandae impedit doloribus."
        />
        <img src="/src/assets/images/tasks.jpg" alt="tasks" className="w-1/3 rounded-full" />
      </div>
      <div className="flex gap-5">
        <img src="/src/assets/images/team_project.jpg" alt="team project" className="w-1/3 rounded-xl" />
        <Paragraph
        heading="heading"
        text="Lorem ipsum, dolor sit amet consectetur adipisicing elit. Id aliquam provident consequatur veritatis tenetur illo voluptatibus! Culpa voluptatum nam, voluptatem aspernatur amet eum. Repellendus fugiat velit perspiciatis repudiandae impedit doloribus."
        />
      </div>
    </div>
  )
}

export default AboutUs