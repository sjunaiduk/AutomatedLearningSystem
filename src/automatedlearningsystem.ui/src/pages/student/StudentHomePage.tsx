import { useAuthStore } from "../../stores/userStore";
import { Typography, Row, Col, Card } from "antd";

const { Title, Paragraph, Text } = Typography;

const StudentHomePage = () => {
  const { User } = useAuthStore();

  return (
    <div className="home-page-container">
      <Row justify="center" style={{ marginBottom: "20px" }}>
        <Col>
          <Title level={1}>Welcome to the Automated Learning System</Title>
          <Text type="secondary">{User?.email}</Text>
        </Col>
      </Row>

      <Paragraph>
        Whether you're looking to sharpen your skills in backend, frontend, or
        database technologies, our platform offers tailored learning paths to
        help you achieve your goals. Engage with interactive lessons and track
        your progress across various modules designed by experts.
      </Paragraph>

      <Row gutter={16}>
        <Col span={8}>
          <Card title="Latest Courses" bordered={false}>
            Dive into the newest and most popular courses designed to push your
            skills to the next level. Each course is updated regularly to ensure
            you learn the latest technologies and practices.
          </Card>
        </Col>

        <Col span={8}>
          <Card title="Your Progress" bordered={false}>
            Track your learning journey and milestones. Review your progress in
            the courses you are enrolled in, and see how far you have come and
            what's next on your path.
          </Card>
        </Col>
      </Row>
    </div>
  );
};

export default StudentHomePage;
