import { Typography, Row, Col, Card } from "antd";

const { Title, Paragraph } = Typography;

const GenericHomePage = () => {
  return (
    <div className="home-page-container">
      <Row justify="center" style={{ marginBottom: "20px" }}>
        <Col>
          <Title level={1}>Welcome to the Automated Learning System</Title>
        </Col>
      </Row>

      <Paragraph>
        Discover a platform designed to revolutionize the way you learn and
        manage educational content. From backend technologies to modern frontend
        design, our courses cover a broad spectrum tailored to beginners and
        advanced users alike.
      </Paragraph>

      <Row gutter={16}>
        <Col span={12}>
          <Card title="Explore Learning Paths" bordered={false}>
            Learn at your own pace with structured paths that guide you from the
            basics to advanced topics in your chosen field.
          </Card>
        </Col>
        <Col span={12}>
          <Card title="Administration Tools" bordered={false}>
            Manage learning items, users and a question base to help improve the
            learning experience of new software developers!
          </Card>
        </Col>
      </Row>
    </div>
  );
};

export default GenericHomePage;
