interface LoginData {
  Email: string;
  Password: string;
}

type Role = "Admin" | "Student";

type Categories = "Frontend" | "Backend" | "Database";

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
  learningItems: LearningItem[];
}

interface LearningItem {
  id: string;
  name: string;
  description: string;
  category: Categories;
  completed: boolean;
}
