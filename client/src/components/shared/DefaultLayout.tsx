import { Outlet } from "react-router-dom"
import Footer from "./Footer"
import Navbar from "./Navbar"

const DefaultLayout = () => {
    return(
        <main>
            <Navbar />
            <div className="flex-grow">
                <Outlet />
            </div>
            <Footer />
        </main>
    )
}

export default DefaultLayout