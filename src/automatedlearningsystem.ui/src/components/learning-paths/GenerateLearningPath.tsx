import { Button } from "antd";
import { useGenerateLearningPaths } from "../../hooks/useGenerateLearningPaths";
import { useAuthStore } from "../../stores/userStore";
import { useQuestions } from "src/hooks/useQuestions/useQuestions";

const GenerateLearningPath = () => {
  const { data } = useQuestions();

  const hardcodedRequestData: GenerateLearningPathRequest = {
    learningPathName: "Test Learning Path",
    Profile: {
      backend: "Beginner",
      database: "Advanced",
      frontend: "Intermediate",
    },
    answers: [
      {
        questionId: (data && data[0].id) as string,
        answer: 3,
      },
    ],
  };

  const { User } = useAuthStore();
  const { mutate } = useGenerateLearningPaths(User!.id);
  return (
    <Button type="primary" onClick={() => mutate(hardcodedRequestData)}>
      Generate
    </Button>
  );
};

export default GenerateLearningPath;
