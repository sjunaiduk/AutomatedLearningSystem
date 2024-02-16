import { useNavigate } from "react-router-dom";
import { client } from "../../../services/apiClient";
import { useAuthStore } from "../stores/userStore";

const useAuth = ({ Email, Password }: LoginData) => {
  const navigate = useNavigate();
  const { LoginUser: Authenticate } = useAuthStore();

  const login = async () => {
    const loginResult = await client.post(`/auth/login`, {
      Email,
      Password,
    });
    if (loginResult.status == 200) {
      navigate("/");
      Authenticate(Email);
    }
  };

  return { login };
};

export default useAuth;
