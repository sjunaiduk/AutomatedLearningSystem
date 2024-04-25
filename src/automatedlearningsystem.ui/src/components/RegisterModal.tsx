import { Modal, Form, Input, Button, Checkbox } from "antd";
import { client } from "src/services/apiClient";

interface Props {
  open: boolean;
  setOpen: (b: boolean) => void;
}
const RegistrationModal = ({ open, setOpen }: Props) => {
  const [form] = Form.useForm();

  const handleRegister = async (values: any) => {
    try {
      await client.post("/auth/register", values);
      setOpen(false);
      form.resetFields();
    } catch (error) {
      console.error("Registration failed:", error);
    }
  };

  const handleCancel = () => {
    setOpen(false);
    form.resetFields();
  };

  return (
    <Modal
      title="Register"
      open={open}
      onCancel={handleCancel}
      onOk={() => form.submit()}
      centered
    >
      <Form form={form} layout="vertical" onFinish={handleRegister}>
        <Form.Item
          name="FirstName"
          label="First Name"
          rules={[{ required: true, message: "Please input your first name!" }]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          name="LastName"
          label="Last Name"
          rules={[{ required: true, message: "Please input your last name!" }]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          name="Email"
          label="Email"
          rules={[
            {
              required: true,
              message: "Please input your email!",
              type: "email",
            },
          ]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          name="Password"
          label="Password"
          rules={[{ required: true, message: "Please input your password!" }]}
        >
          <Input.Password />
        </Form.Item>
        <Form.Item name="Token" label="Invitation Token (Optional)">
          <Input />
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default RegistrationModal;
