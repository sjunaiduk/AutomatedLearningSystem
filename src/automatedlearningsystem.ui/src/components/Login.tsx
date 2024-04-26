import { Button, Checkbox, Form, Input, Typography } from "antd";
import { useState } from "react";
import { useLogin } from "src/hooks/useLogin";
import RegistrationModal from "./RegisterModal";
import { LockOutlined, MailOutlined } from "@ant-design/icons";

const { Text, Title } = Typography;

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [registerOpen, setRegisterOpen] = useState(false);
  const { login } = useLogin({ Email: email, Password: password });

  return (
    <section style={{ display: "flex", justifyContent: "center" }}>
      <div>
        <div>
          <Title>Sign in</Title>
          <Typography.Text>
            Welcome back to AntBlocks UI! Please enter your details below to
            sign in.
          </Typography.Text>
        </div>
        <Form
          name="normal_login"
          initialValues={{
            remember: true,
          }}
          onFinish={login}
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
              data-testid={"login-button"}
            >
              Log in
            </Button>
            <div>
              <Text>Don't have an account?</Text>{" "}
              <Button type="link" onClick={() => setRegisterOpen(true)}>
                Sign up now
              </Button>
            </div>
          </Form.Item>
        </Form>

        <RegistrationModal open={registerOpen} setOpen={setRegisterOpen} />
      </div>
    </section>
  );
};

export default Login;
