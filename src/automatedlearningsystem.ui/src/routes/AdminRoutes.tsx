import { useAuthStore } from "../features/authentication/stores/userStore";
import { Navigate, Outlet } from "react-router-dom";

const AdminRoutes = () => {
  const { User } = useAuthStore();
  if (User?.role !== "Admin") {
    console.log("Student tried to access an admin route");
    return <Navigate to={"/"} />;
  }
  return <Outlet />;
};

export default AdminRoutes;
