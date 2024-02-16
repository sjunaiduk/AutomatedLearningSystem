import { ItemType } from "antd/es/menu/hooks/useItems";
import { useAuthStore } from "../features/authentication/stores/userStore";
import {
  LoginOutlined,
  LogoutOutlined,
  UserOutlined,
  BookOutlined,
} from "@ant-design/icons";
import { useNavigate } from "react-router-dom";
import { useLogout } from "../features/authentication/hooks/useLogout";

const useNavigationItems = (): ItemType[] => {
  const { User } = useAuthStore();
  const { logout } = useLogout();
  const navigate = useNavigate();
  const items: ItemType[] = [];

  if (User == null) {
    items.push({
      key: "1",
      label: "Login",
      icon: <LoginOutlined />,
      onClick: () => navigate("/login"),
    });
  } else {
    items.push({
      key: "1",
      label: "Logout",
      icon: <LogoutOutlined />,
      onClick: () => {
        logout();
      },
    });

    if (User.Role == "Admin") {
      items.push({
        key: "2",
        label: "Users",
        icon: <UserOutlined />,
      });
    } else {
      items.push({
        key: "2",
        label: "My Learning Paths",
        icon: <BookOutlined />,
      });
    }
  }

  return items;
};

export default useNavigationItems;
