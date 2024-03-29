import { ItemType } from "antd/es/menu/hooks/useItems";
import { useAuthStore } from "../stores/userStore";
import {
  LoginOutlined,
  LogoutOutlined,
  UserOutlined,
  BookOutlined,
  QuestionCircleTwoTone,
} from "@ant-design/icons";
import { useNavigate } from "react-router-dom";
import { useLogout } from "./useLogout";

const useNavigationItems = (): ItemType[] => {
  const { User } = useAuthStore();
  const { logout } = useLogout();
  const navigate = useNavigate();
  const items: ItemType[] = [];

  if (User == null) {
    items.push({
      key: "1",
      label: "Login",
      icon: <LoginOutlined data-testid={"login-nav-button"} />,
      onClick: () => navigate("/login"),
    });
  } else {
    items.push({
      key: "1",
      label: "Logout",
      icon: <LogoutOutlined id="123" data-testid={"logout-button"} />,

      onClick: () => {
        logout();
      },
    });

    if (User.role == "Admin") {
      items.push({
        key: "2",
        label: "Users",
        icon: <UserOutlined />,
        onClick: () => navigate("/users"),
      });
    } else {
      items.push({
        key: "2",
        label: "My Learning Paths",
        icon: <BookOutlined />,
        onClick: () => navigate("/learning-paths"),
      });
      items.push({
        key: "3",
        label: "Questionnare",
        icon: <QuestionCircleTwoTone />,
        onClick: () => navigate("/questionnare"),
      });
    }
  }

  return items;
};

export default useNavigationItems;
