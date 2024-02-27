import { Menu } from "antd";
import useNavigationItems from "../../hooks/useNavigationItems";
import "../../App.css";
export const Navbar = () => {
  const items = useNavigationItems();
  return (
    <Menu
      theme="dark"
      defaultSelectedKeys={["1"]}
      mode="inline"
      items={items}
    />
  );
};
