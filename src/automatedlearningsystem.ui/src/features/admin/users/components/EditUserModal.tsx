import { Modal, Button, Input, Select, Form } from "antd";
import { useEffect, useState } from "react";
import { useUpdateUser } from "../hooks/useUpdateUser";

const { Option } = Select;

interface Props {
  open: boolean;
  setOpen: (b: boolean) => void;
  user: User;
}
const EditUserModal = ({ open, setOpen, user }: Props) => {
  const [confirmLoading, setConfirmLoading] = useState(false);
  const { mutate: updateUser } = useUpdateUser();
  const [form] = Form.useForm<User>();

  useEffect(() => {
    if (open) {
      console.log("setting form defaults");

      form.setFieldsValue({
        firstName: user.firstName,
        lastName: user.lastName,
        email: user.email,
        password: user.password,
        role: user.role,
      });
    }
  }, [open]);

  const handleOk = async () => {
    setConfirmLoading(true);
    try {
      var data = await form.validateFields();
      setOpen(false);
      setConfirmLoading(false);
      updateUser({
        ...data,
        id: user.id,
      });
    } catch (info) {
      setConfirmLoading(false);
    }
  };

  const handleCancel = () => {
    setOpen(false);
  };
  return (
    <Modal
      title="Edit User"
      open={open}
      onOk={handleOk}
      confirmLoading={confirmLoading}
      onCancel={handleCancel}
      centered
      footer={[
        <Button key="back" onClick={handleCancel}>
          Cancel
        </Button>,
        <Button
          key="submit"
          type="primary"
          loading={confirmLoading}
          onClick={handleOk}
        >
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

export default EditUserModal;
