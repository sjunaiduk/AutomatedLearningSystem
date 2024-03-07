import { Modal, Button, Input, Select, Form } from "antd";
import { useAddUser } from "src/hooks/users/useAddUser/useAddUser";

const { Option } = Select;

interface Props {
  open: boolean;
  setOpen: (b: boolean) => void;
}
const AddUserModal = ({ open, setOpen }: Props) => {
  const { mutate: addUser } = useAddUser();
  const [form] = Form.useForm<User>();

  const handleOk = async () => {
    var data = await form.validateFields();
    setOpen(false);
    addUser(data);
  };

  const handleCancel = () => {
    setOpen(false);
  };
  return (
    <Modal
      title="Add User"
      open={open}
      onOk={handleOk}
      onCancel={handleCancel}
      centered
      footer={[
        <Button key="back" onClick={handleCancel}>
          Cancel
        </Button>,
        <Button key="submit" type="primary" onClick={handleOk}>
          Submit
        </Button>,
      ]}
    >
      <Form form={form} layout="vertical" name="userForm">
        <Form.Item
          name="firstName"
          label="First Name"
          rules={[{ required: true, message: "Please input the first name!" }]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          name="lastName"
          label="Last Name"
          rules={[{ required: true, message: "Please input the last name!" }]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          name="email"
          label="Email"
          rules={[
            {
              required: true,
              type: "email",
              message: "Please input a valid email!",
            },
          ]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          name="password"
          label="Password"
          rules={[{ required: true, message: "Please input the password!" }]}
        >
          <Input.Password />
        </Form.Item>
        <Form.Item
          name="role"
          label="Role"
          rules={[{ required: true, message: "Please select a role!" }]}
        >
          <Select placeholder="Select a role">
            <Option value="admin">Admin</Option>
            <Option value="student">Student</Option>
          </Select>
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default AddUserModal;
