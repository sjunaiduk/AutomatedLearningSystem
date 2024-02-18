import "../../../App.css";
import { useAuthStore } from "../../authentication/stores/userStore";

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
