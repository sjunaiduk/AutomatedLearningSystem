import { createBrowserRouter } from "react-router-dom";
import LayoutPage from "../pages/LayoutPage";
import HomePage from "../features/admin/pages/HomePage";
import { LoginPage } from "../features/authentication/pages/LoginPage";
import ProtectedRoutes from "./ProtectedRoutes";
import AdminRoutes from "./AdminRoutes";

import UsersPage from "../features/admin/users/pages/UsersPage";
import LearningPathsPage from "../features/learningPaths/pages/LearningPathsPage";
import QuestionnarePage from "../features/learningPaths/pages/QuestionnarePage";
export const routerConfig = [
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
          {
            path: "/questionnare",
            element: <QuestionnarePage />,
          },
        ],
      },
      {
        path: "/login",
        element: <LoginPage />,
      },
    ],
  },
];
const router = createBrowserRouter(routerConfig);

export default router;
