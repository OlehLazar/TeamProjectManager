import { Outlet } from "react-router-dom"
import Footer from "./Footer"
import Navbar from "./Navbar"

const DefaultLayout = () => {
    return(
        <main className="flex flex-col bg-[#ffffff] min-h-screen">
            <Navbar />
            <div className="flex-grow content-center">
                <Outlet />
            </div>
            <Footer />
        </main>
    )
}

export default DefaultLayout