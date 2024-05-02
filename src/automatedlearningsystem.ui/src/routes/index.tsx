import { createBrowserRouter } from "react-router-dom";
import LayoutPage from "../pages/LayoutPage";
import ProtectedRoutes from "./ProtectedRoutes";
import AdminRoutes from "./AdminRoutes";
import UsersPage from "../pages/admin/UsersPage";
import LearningPathsPage from "../pages/LearningPathsPage";
import LearningItemsPage from "../pages/admin/LearningItemsPage";
import LearningPathsReportPage from "../pages/admin/ReportsPage";
import GenericHomePage from "../pages/GenericHomePage";
import AdminHomePage from "../pages/admin/AdminHomePage";
import StudentHomePage from "../pages/student/StudentHomePage";
import { LoginPage } from "src/pages/authentication/LoginPage";
import QuestionnarePage from "src/pages/QuestionnarePage";

export const routerConfig = [
  {
    path: "/",
    element: <LayoutPage />,
    children: [
      { path: "/", element: <GenericHomePage /> },
      {
        path: "login",
        element: <LoginPage />,
      },
      {
        path: "/",
        element: <ProtectedRoutes />,
        children: [
          {
            path: "admin",
            element: <AdminRoutes />,
            children: [
              { path: "", element: <AdminHomePage /> },
              { path: "users", element: <UsersPage /> },
              { path: "learning-items", element: <LearningItemsPage /> },
              { path: "report", element: <LearningPathsReportPage /> },
            ],
          },
          {
            path: "student",
            element: <StudentHomePage />,
          },
          { path: "student/learning-paths", element: <LearningPathsPage /> },
          { path: "student/questionnaire", element: <QuestionnarePage /> },
        ],
      },
    ],
  },
];

const router = createBrowserRouter(routerConfig);

export default router;
