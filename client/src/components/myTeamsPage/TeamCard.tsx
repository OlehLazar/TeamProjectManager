import Button from "../shared/Button"

const TeamCard = () => {
  return (
    <div className="p-3 border border-gray-300 rounded-lg shadow-black shadow-sm flex flex-col">
        <h1 className="font-semibold text-xl font-ptSerif">Team name</h1>
        <p>Team description Lorem ipsum dolor sit amet consectetur adipisicing elit. Cupiditate, cum repellat pariatur aliquid mollitia quo nam dolores repudiandae asperiores ullam nostrum, molestiae temporibus deserunt, illo in recusandae quae! Cum, et?</p>
        <Button width="w-1/3">View team</Button>
    </div>
  )
}

export default TeamCard