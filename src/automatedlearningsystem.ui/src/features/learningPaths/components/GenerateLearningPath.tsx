import { Button } from "antd";
import { useGenerateLearningPaths } from "../hooks/useGenerateLearningPaths";
import { useAuthStore } from "../../authentication/stores/userStore";

const hardcodedRequestData: GenerateLearningPathRequest = {
  learningPathName: "Test Learning Path",
  Profile: {
    backend: "Beginner",
    database: "Advanced",
    frontend: "Intermediate",
  },
  answers: [
    {
      questionId: "2A234AE7-9630-42F2-9E2C-4239548031F8",
      answer: 3,
    },
  ],
};

const GenerateLearningPath = () => {
  const { User } = useAuthStore();
  const { mutate } = useGenerateLearningPaths(User!.id);
  return (
    <Button type="primary" onClick={() => mutate(hardcodedRequestData)}>
      Generate
    </Button>
  );
};

export default GenerateLearningPath;
