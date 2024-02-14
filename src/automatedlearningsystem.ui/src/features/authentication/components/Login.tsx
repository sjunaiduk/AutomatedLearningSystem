import { Button, Checkbox, Form, Input, Typography } from "antd";
import axios from "axios";
import { LockOutlined, MailOutlined } from "@ant-design/icons";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuthStore } from "../stores/userStore";

const { Text, Title, Link } = Typography;

interface LoginRequest {
  Email: string;
  Password: string;
}
const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();
  const { Authenticate } = useAuthStore();

  const onFinish = async (data: LoginRequest) => {
    const loginResult = await axios.post(
      `${import.meta.env.VITE_API_BASE}/auth/login`,
      {
        Email: data.Email,
        Password: data.Password,
      },
      {
        withCredentials: true,
      }
    );
    console.log(loginResult);
    if (loginResult.status == 200) {
      navigate("/");
      Authenticate(data.Email);
    }
  };

  return (
    <section
      style={{
        display: "flex",
        justifyContent: "center",
      }}
    >
      <div>
        <div>
          <Title>Sign in</Title>
          <Text>
            Welcome back to AntBlocks UI! Please enter your details below to
            sign in.
          </Text>
        </div>
        <Form
          name="normal_login"
          initialValues={{
            remember: true,
          }}
          onFinish={onFinish}
          layout="vertical"
          requiredMark="optional"
        >
          <Form.Item name="Email">
            <Input
              prefix={<MailOutlined />}
              placeholder="Email"
              value={email}
              onChange={(e) => {
                setEmail(e.target.value);
              }}
            />
          </Form.Item>
          <Form.Item
            name="Password"
            rules={[
              {
                required: true,
                message: "Please input your Password!",
              },
            ]}
          >
            <Input.Password
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              prefix={<LockOutlined />}
              type="password"
              placeholder="Password"
            />
          </Form.Item>
          <Form.Item style={{ marginBottom: "0.5rem" }}>
            <Form.Item name="remember" valuePropName="checked" noStyle>
              <Checkbox>Remember me</Checkbox>
            </Form.Item>
            <a href="">Forgot password?</a>
          </Form.Item>
          <Form.Item>
            <Button
              type="primary"
              htmlType="submit"
              style={{ marginBottom: "1rem" }}
            >
              Log in
            </Button>
            <div>
              <Text>Don't have an account?</Text>{" "}
              <Link href="">Sign up now</Link>
            </div>
          </Form.Item>
        </Form>
      </div>
    </section>
  );
};

export default Login;
