import { useAuthStore } from "../stores/userStore";
import { Outlet } from "react-router-dom";

const ProtectedRoutes = () => {
  const { Authenticated } = useAuthStore();

  console.log("auth: ", Authenticated);
  if (Authenticated) {
    return <Outlet />;
  }
  return <h1>Please login</h1>;
};

export default ProtectedRoutes;
