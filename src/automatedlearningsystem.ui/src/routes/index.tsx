import { createBrowserRouter } from "react-router-dom";
import LayoutPage from "../pages/LayoutPage";
import HomePage from "../pages/admin/HomePage";
import { LoginPage } from "../pages/authentication/LoginPage";
import ProtectedRoutes from "./ProtectedRoutes";
import AdminRoutes from "./AdminRoutes";

import UsersPage from "../pages/admin/UsersPage";
import LearningPathsPage from "../pages/LearningPathsPage";
import QuestionnarePage from "../pages/QuestionnarePage";
import LearningItemsPage from "src/pages/admin/LearningItemsPage";
import LearningPathsReportPage from "src/pages/admin/ReportsPage";
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
              {
                path: "/learning-items",
                element: <LearningItemsPage />,
              },
              {
                path: "/report",
                element: <LearningPathsReportPage />,
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
