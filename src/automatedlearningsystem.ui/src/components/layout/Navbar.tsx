import { LoginOutlined } from "@ant-design/icons";
import { Menu } from "antd";
import { ItemType } from "antd/es/menu/hooks/useItems";
import { useNavigate } from "react-router-dom";

export const Navbar = () => {
  const items: ItemType[] = [
    {
      key: "1",
      label: "Login",
      icon: <LoginOutlined />,
      onClick: () => navigate("/login"),
    },
  ];
  var navigate = useNavigate();

  return (
    <Menu
      theme="dark"
      defaultSelectedKeys={["1"]}
      mode="inline"
      items={items}
    />
  );
};
