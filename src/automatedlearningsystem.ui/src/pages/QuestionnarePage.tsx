import Title from "antd/es/typography/Title";
import GenerateLearningPath from "../components/learning-paths/GenerateLearningPath";

const QuestionnarePage = () => {
  return (
    <div>
      <Title level={1}>Dynamic Learning Path Generator</Title>

      <GenerateLearningPath />
    </div>
  );
};

export default QuestionnarePage;
