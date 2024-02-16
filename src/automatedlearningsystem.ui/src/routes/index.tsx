import { createBrowserRouter } from "react-router-dom";
import LayoutPage from "../pages/LayoutPage";
import HomePage from "../features/admin/pages/HomePage";
import { LoginPage } from "../features/authentication/pages/LoginPage";
import ProtectedRoutes from "./ProtectedRoutes";

const router = createBrowserRouter([
  {
    path: "/",
    element: <LayoutPage />,
    children: [
      {
        path: "",
        element: <ProtectedRoutes />,
        children: [
          {
            path: "",
            element: <HomePage />,
          },
        ],
      },
      {
        path: "/login",
        element: <LoginPage />,
      },
    ],
  },
]);

export default router;
