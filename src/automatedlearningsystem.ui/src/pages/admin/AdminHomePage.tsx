import { Typography, Row, Col, Card } from "antd";
import "src/App.css";

const { Title, Paragraph } = Typography;

const AdminHomePage = () => {
  return (
    <div className="home-page-container">
      <Row justify="center" style={{ marginBottom: "20px" }}>
        <Col>
          <Title level={1}>Admin Dashboard</Title>
        </Col>
      </Row>

      <Paragraph>
        Access comprehensive management tools and insights to oversee course
        offerings, user engagement, and educational outcomes.
      </Paragraph>

      <Row gutter={16}>
        <Col span={12}>
          <Card title="User Management" bordered={false}>
            Oversee and manage user accounts, roles, and permissions to maintain
            the integrity and security of the platform.
          </Card>
        </Col>
        <Col span={12}>
          <Card title="Analytics and Reporting" bordered={false}>
            Utilize detailed reports and analytics to make informed decisions
            about courses, content, and user activity.
          </Card>
        </Col>
      </Row>
    </div>
  );
};

export default AdminHomePage;
