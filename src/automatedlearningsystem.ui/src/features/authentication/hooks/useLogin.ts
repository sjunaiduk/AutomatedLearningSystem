import { useMutation } from "@tanstack/react-query";
import authService from "../services/authService";
import { useNavigate } from "react-router-dom";
import { useAuthStore } from "../stores/userStore";

export const useLogin = ({ Email, Password }: LoginData) => {
  const navigate = useNavigate();
  const { LoginUser } = useAuthStore();
  const { mutate } = useMutation({
    mutationFn: () => authService.Login({ Email, Password }),
    onSuccess: () => {
      console.log("Login was successful");
      LoginUser(Email);
      navigate("/");
    },
    onError: () => console.log("Login failed"),
  });

  return {
    login: mutate,
  };
};
