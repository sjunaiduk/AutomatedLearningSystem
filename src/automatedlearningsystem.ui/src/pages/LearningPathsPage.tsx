import { useLearningPaths } from "src/hooks/useLearningPaths";
import LearningPathsTable from "../components/learning-paths/LearningPathsTable";
import { useAuthStore } from "src/stores/userStore";

const LearningPathsPage = () => {
  const { User } = useAuthStore();
  const { data: learningPaths } = useLearningPaths(User!.id);
  return (
    <div>
      LearningPathsPage
      <div>
        <LearningPathsTable learningPaths={learningPaths || []} />
      </div>
    </div>
  );
};

export default LearningPathsPage;
