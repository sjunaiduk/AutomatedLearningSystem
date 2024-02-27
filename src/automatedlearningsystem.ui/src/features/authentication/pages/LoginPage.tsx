import { Navigate } from "react-router-dom";
import Login from "../components/Login";
import { useAuthStore } from "../stores/userStore";

export const LoginPage = () => {
  const { Authenticated } = useAuthStore();
  if (Authenticated) {
    return <Navigate to="/" />;
  }
  return <Login />;
};
