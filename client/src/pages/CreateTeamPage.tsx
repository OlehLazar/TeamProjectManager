import { useState } from "react";
import { createTeam } from "../services/teamService";
import axios from "axios";
import Button from "../components/shared/Button"
import Input from "../components/shared/Input"

const CreateTeamPage = () => {
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [errorMessage, setErrorMessage] = useState("");

    const handleCreate = async () => {
        try {
            await createTeam({ name: name, description: description });
            window.location.href = "/teams";
        } catch (error: unknown) {
            console.error("Creation failed:", error);

            if (axios.isAxiosError(error)) {
                const errors = error.response?.data?.errors;
                if (errors) {
                  const errorMessages = Object.values(errors).flat().join(", ");
                  setErrorMessage(errorMessages);
                  return;
                }
            }

            setErrorMessage("An unexpected error occured.");
        }
    };

    return (
        <div className="pt-10 pb-10 flex flex-col justify-center text-center gap-5 mx-auto w-1/2">
            <h1 className="font-ptSerif text-2xl font-semibold">Create a new team</h1>
            <Input name="name" placeholder="Name" width="w-1/3" value={name} onChange={(e) => setName(e.target.value)} />
            <div>
                <textarea placeholder="Description" className="focus:outline-none border-b border-[#1111116a]"
                value={description} onChange={(e) => setDescription(e.target.value)} />
            </div>
            <Button width="w-1/5" onClick={handleCreate} >Create</Button>
            {errorMessage && <p className="text-red-500 mt-2">{errorMessage}</p>}
        </div>
    )
}

export default CreateTeamPage