interface LoginData {
  Email: string;
  Password: string;
}

interface User {
  id: string;
  role: "Admin" | "Student";
  email: string;
  firstName: string;
  lastName: string;
  password: string;
}
