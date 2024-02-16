import { useMutation } from "@tanstack/react-query";
import authService from "../services/authService";
import { useNavigate } from "react-router-dom";
import { useAuthStore } from "../stores/userStore";

export const useLogout = () => {
  const navigate = useNavigate();
  const { LogoutUser } = useAuthStore();
  const { mutate } = useMutation({
    mutationFn: authService.Logout,
    onSuccess: () => {
      console.log("Logout was successful");
      LogoutUser();
      navigate("/");
    },
    onError: () => console.log("Logout failed"),
  });

  return {
    logout: mutate,
  };
};
