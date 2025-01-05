import Button from "../components/shared/Button"
import Input from "../components/shared/Input"
import TeamCard from "../components/myTeamsPage/TeamCard"

const MyTeamsPage = () => {
  return (
    <div className="pt-5 pb-5 flex flex-col justify-between items-center">
      <div className="flex w-1/2 mx-auto p-5">
        <Input name="team_search" placeholder="Search for a team" width="w-1/2" />
        <Button width="w-1/4">Create a team</Button>
      </div>
      <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5 w-4/5 mx-auto pt-5 pb-5">
        <li>
          <TeamCard />
        </li>
        <li>
          <TeamCard />
        </li>
        <li>
          <TeamCard />
        </li>
        <li>
          <TeamCard />
        </li>
      </ul>
    </div>
  )
}

export default MyTeamsPage