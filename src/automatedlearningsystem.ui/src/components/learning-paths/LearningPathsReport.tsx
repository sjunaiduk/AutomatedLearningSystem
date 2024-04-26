import { useEffect, useState } from "react";
import { Table, Typography } from "antd";
import { client } from "src/services/apiClient";

const { Title } = Typography;

const LearningPathsReport = () => {
  const [learningPaths, setLearningPaths] = useState([]);

  useEffect(() => {
    const fetchLearningPaths = async () => {
      try {
        const response = await client.get("api/reports");
        setLearningPaths(response.data);
      } catch (error) {
        console.error("Failed to fetch learning paths:", error);
      }
    };

    fetchLearningPaths();
  }, []);

  const columns = [
    {
      title: "Learning Path Name",
      dataIndex: "learningPathName",
      key: "learningPathName",
    },
    {
      title: "User Name",
      dataIndex: "userName",
      key: "userName",
    },
    {
      title: "Progress",
      dataIndex: "percentageProgress",
      key: "percentageProgress",
      render: (progress: number) => `${progress}%`,
    },
  ];

  return (
    <div>
      <Title level={2}>Learning Paths Progress Report</Title>
      <Table
        dataSource={learningPaths}
        columns={columns}
        rowKey="learningPathId"
      />
    </div>
  );
};

export default LearningPathsReport;
