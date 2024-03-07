import { Footer } from "antd/es/layout/layout";

const FooterComponent = () => {
  return (
    <Footer style={{ textAlign: "center" }} data-testid="footer">
      Ant Design ©{new Date().getFullYear()} Created by Ant UED
    </Footer>
  );
};

export default FooterComponent;
