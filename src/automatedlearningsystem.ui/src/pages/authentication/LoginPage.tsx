import { Navigate } from "react-router-dom";
import Login from "../../components/Login";
import { useAuthStore } from "../../stores/userStore";

export const LoginPage = () => {
  const { Authenticated, User } = useAuthStore();
  if (Authenticated) {
    return <Navigate to={User?.role === "Admin" ? "/admin" : "/student"} />;
  }
  return <Login />;
};
