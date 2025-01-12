const TeamPage = () => {
  return (
    <div className="pt-5 pb-5 pl-10 pr-10 flex flex-col gap-3">
        <h1 className="font-ptSerif font-semibold text-3xl">Team Name</h1>
        <h1 className="font-ptSerif text-2xl">Team description:</h1>
        <p className="font-openSans text-lg">
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Veniam magni officiis sit ipsa dolores cum eum, 
            cupiditate quia explicabo perspiciatis adipisci. Iusto eos, quo quibusdam suscipit laborum quia illo aperiam.
        </p>

        <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5 pt-5 pb-5">
            <li>
                <div className="p-3 border border-gray-300 rounded-lg shadow-black shadow-sm flex flex-col">
                    <h1 className="font-semibold text-xl font-ptSerif">Board name</h1>
                    <p>Board description</p>
                </div>
            </li>
        </ul>

        <ul className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5 pt-5 pb-5">
            <li>
                <div className="p-3 border border-gray-300 rounded-lg shadow-black shadow-sm flex flex-col">
                    <h1 className="font-semibold text-xl font-ptSerif">Member name</h1>
                    <p>Member role</p>
                </div>
            </li>
        </ul>
    </div>
  )
}

export default TeamPage