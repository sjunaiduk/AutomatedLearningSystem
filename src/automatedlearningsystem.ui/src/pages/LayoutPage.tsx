import React, { useState } from "react";
import { Layout, theme } from "antd";
import { Navbar } from "../components/Navbar";
import { Outlet } from "react-router-dom";
import FooterComponent from "../components/Footer/Footer";

const { Content, Sider } = Layout;

const LayoutPage: React.FC = () => {
  const [collapsed, setCollapsed] = useState(false);
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();

  return (
    <Layout style={{ minHeight: "100vh" }}>
      <Sider
        collapsible
        collapsed={collapsed}
        onCollapse={(value) => setCollapsed(value)}
      >
        <Navbar />
      </Sider>
      <Layout>
        <Content style={{ margin: "2rem 16px" }}>
          <div
            style={{
              padding: 24,
              minHeight: 360,
              background: colorBgContainer,
              borderRadius: borderRadiusLG,
            }}
          >
            <Outlet />
          </div>
        </Content>
        <FooterComponent />
      </Layout>
    </Layout>
  );
};

export default LayoutPage;
