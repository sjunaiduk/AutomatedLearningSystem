import { useLearningPaths } from "src/hooks/useLearningPaths";
import LearningPathsTable from "../components/learning-paths/LearningPathsTable";
import { useAuthStore } from "src/stores/userStore";
import Title from "antd/es/typography/Title";

const LearningPathsPage = () => {
  const { User } = useAuthStore();
  const { data: learningPaths } = useLearningPaths(User!.id);
  return (
    <div>
      <Title level={1}>
        {User?.firstName} {User?.lastName}'s Learning Paths
      </Title>
      <div>
        <LearningPathsTable learningPaths={learningPaths || []} />
      </div>
    </div>
  );
};

export default LearningPathsPage;
