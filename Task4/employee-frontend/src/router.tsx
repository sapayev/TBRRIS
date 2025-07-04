import { createBrowserRouter } from "react-router-dom";
import AboutPage from "@/pages/AboutPage";
import EmployeesPage from "@/pages/EmployeesPage";

export default createBrowserRouter([
    { path: "/", element: <AboutPage /> },
    { path: "/employees", element: <EmployeesPage /> },
]);
