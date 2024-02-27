import { useMutation } from "@tanstack/react-query";
import authService from "../services/authService";
import { useAuthStore } from "../stores/userStore";

export const useLogin = ({ Email, Password }: LoginData) => {
  const { LoginUser } = useAuthStore();
  const { mutate } = useMutation({
    mutationFn: () => authService.Login({ Email, Password }),
    onSuccess: (loginResponse) => {
      console.log("Login success ", loginResponse);
      LoginUser(loginResponse);
    },
    onError: () => console.log("Login failed"),
  });

  return {
    login: mutate,
  };
};
