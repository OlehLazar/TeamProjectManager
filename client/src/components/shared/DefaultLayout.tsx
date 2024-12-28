import { Outlet } from "react-router-dom"
import Footer from "./Footer"
import Navbar from "./Navbar"

const DefaultLayout = () => {
    return(
        <main className="bg-[#a0aecd] min-h-screen">
            <Navbar />
            <div className="flex-grow">
                <Outlet />
            </div>
            <Footer />
        </main>
    )
}

export default DefaultLayout