import { useAuthStore } from "../../stores/userStore";
import "../../../App.css";

const HomePage = () => {
  const { User } = useAuthStore();
  return (
    <div>
      <h1>Automated Learning System</h1>
      <span>{User?.email}</span>
      <p>home page content</p>
    </div>
  );
};

export default HomePage;
