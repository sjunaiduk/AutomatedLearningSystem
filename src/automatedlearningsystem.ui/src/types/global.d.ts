interface LoginData {
  Email: string;
  Password: string;
}

type Role = "Admin" | "Student";

type Categories = "Frontend" | "Backend" | "Database";

type UserLevel = "Beginner" | "Intermediate" | "Advanced";

interface LoginResponse {
  id: string;
  role: Role;
  firstName: string;
  lastName: string;
  email: string;
}

interface User {
  id: string;
  role: Role;
  email: string;
  firstName: string;
  lastName: string;
  password: string;
}

interface LearningPath {
  id: string;
  name: string;
  userLearningItems: LearningItem[];
}

interface LearningItem {
  id: string;
  name: string;
  description: string;
  category: Categories;
  completed: boolean;
}

interface Answer {
  questionId: string;
  answer: number;
}

interface Profile {
  frontend: UserLevel;
  backend: UserLevel;
  database: UserLevel;
}
interface GenerateLearningPathRequest {
  answers: Answers[];
  Profile: Profile;
  learningPathName: string;
}
