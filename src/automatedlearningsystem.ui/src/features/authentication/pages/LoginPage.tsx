import { Navigate } from "react-router-dom";
import Login from "../components/Login";
import { useAuthStore } from "../stores/userStore";

export const LoginPage = () => {
  const { Authenticated } = useAuthStore();
  if (Authenticated) {
    console.log("User is already authenticated, redirecting to /");
    return <Navigate to="/" />;
  }
  return <Login />;
};
