import { createBrowserRouter } from "react-router-dom";
import LayoutPage from "../pages/LayoutPage";
import HomePage from "../features/admin/pages/HomePage";
import { LoginPage } from "../features/authentication/pages/LoginPage";
import ProtectedRoutes from "./ProtectedRoutes";
import AdminRoutes from "./AdminRoutes";

import UsersPage from "../features/admin/users/pages/UsersPage";
import LearningPathsPage from "../features/student/learningPaths/pages/LearningPathsPage";

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
          {
            path: "",
            element: <AdminRoutes />,
            children: [
              {
                path: "/users",
                element: <UsersPage />,
              },
            ],
          },
          {
            path: "/learning-paths",
            element: <LearningPathsPage />,
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
