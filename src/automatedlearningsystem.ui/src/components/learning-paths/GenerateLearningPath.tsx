import { useState, useEffect } from "react";
import {
  Button,
  Radio,
  Card,
  Typography,
  Progress,
  message,
  Input,
  Form,
  Select,
} from "antd";
import { useGenerateLearningPaths } from "../../hooks/useGenerateLearningPaths";
import { useAuthStore } from "../../stores/userStore";
import { useQuestions } from "src/hooks/useQuestions/useQuestions";

const { Title, Paragraph } = Typography;

const GenerateLearningPath = () => {
  const { data: questions } = useQuestions();
  const { User } = useAuthStore();
  const { mutate, status } = useGenerateLearningPaths(User!.id);
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(-1); // Start before the first question
  const [answers, setAnswers] = useState<Answer[]>([]);
  const [currentAnswer, setCurrentAnswer] = useState(3);
  const [learningPathName, setLearningPathName] = useState("");
  const [profile, setProfile] = useState<UserProfile>({
    backend: "Beginner",
    database: "Beginner",
    frontend: "Beginner",
  });

  useEffect(() => {
    if (status === "error") {
      message.error("An error occurred while generating the learning path.");
    } else if (status === "success") {
      message.success("Learning path has been generated successfully.");
    }
  }, [status]);

  const handleAnswerChange = (answer: number) => {
    const updatedAnswers = [...answers];
    updatedAnswers[currentQuestionIndex] = {
      questionId: questions![currentQuestionIndex].id,
      answer,
    };
    setAnswers(updatedAnswers);
  };

  const handleNextQuestion = () => {
    if (currentQuestionIndex === -1) {
      if (
        !learningPathName ||
        !profile.backend ||
        !profile.database ||
        !profile.frontend
      ) {
        message.warning("Please provide all the required information.");
        return;
      }
      setCurrentQuestionIndex(currentQuestionIndex + 1);
      console.log("current profile ", profile);
      return;
    }

    if (currentQuestionIndex < questions!.length - 1) {
      handleAnswerChange(currentAnswer);
      setCurrentAnswer(3);
      setCurrentQuestionIndex(currentQuestionIndex + 1);
    } else {
      const requestData: GenerateLearningPathRequest = {
        learningPathName,
        Profile: profile,
        answers,
      };

      mutate(requestData);
    }
  };

  if (currentQuestionIndex === -1) {
    return (
      <Card>
        <Form layout="vertical">
          <Title level={4}>Create Your Learning Path</Title>
          <Form.Item
            label="Learning Path Name"
            required
            tooltip="This is a required field"
          >
            <Input
              placeholder="Enter Learning Path Name"
              value={learningPathName}
              onChange={(e) => setLearningPathName(e.target.value)}
            />
          </Form.Item>
          <Paragraph>Select your proficiency levels:</Paragraph>
          {["backend", "database", "frontend"].map((area) => (
            <Form.Item
              label={`${
                area.charAt(0).toUpperCase() + area.slice(1)
              } Proficiency`}
              key={area}
            >
              <Select
                value={profile[area]}
                onChange={(value: string) =>
                  setProfile({ ...profile, [area]: value })
                }
              >
                {["Beginner", "Intermediate", "Advanced"].map((level) => (
                  <Radio key={level} value={level}>
                    {level}
                  </Radio>
                ))}
              </Select>
            </Form.Item>
          ))}
          <Form.Item>
            <Button type="primary" onClick={handleNextQuestion}>
              Start
            </Button>
          </Form.Item>
        </Form>
      </Card>
    );
  }

  if (!questions || questions.length === 0) return <div>Loading...</div>;

  return (
    <Card>
      <Progress
        percent={Math.round(
          ((currentQuestionIndex + 1) / questions.length) * 100
        )}
        status="active"
      />
      <Title level={4}>{questions[currentQuestionIndex].description}</Title>
      <Paragraph>Please rate your confidence (1 - least, 5 - most):</Paragraph>
      <Radio.Group
        onChange={(e) => setCurrentAnswer(e.target.value)}
        value={currentAnswer}
      >
        {Array.from({ length: 5 }, (_, i) => (
          <Radio key={i + 1} value={i + 1}>
            {i + 1}
          </Radio>
        ))}
      </Radio.Group>
      <Button
        type="primary"
        onClick={handleNextQuestion}
        style={{ marginTop: 16 }}
      >
        {currentQuestionIndex < questions.length - 1 ? "Next" : "Submit"}
      </Button>
    </Card>
  );
};

export default GenerateLearningPath;
