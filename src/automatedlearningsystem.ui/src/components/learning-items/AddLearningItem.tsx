import { Modal, Button, Input, Select, Form } from "antd";
import axios from "axios";
import { client } from "src/services/apiClient";

const { Option } = Select;

interface Props {
  open: boolean;
  setOpen: (b: boolean) => void;
}

const AddLearningItem = ({ open, setOpen }: Props) => {
  const [form] = Form.useForm();

  const handleOk = async () => {
    try {
      const values = await form.validateFields();
      await client.post("/api/learning-items", {
        Name: values.name,
        Description: values.description,
        Category: values.category,
        Priority: values.priority,
        UserLevel: values.userLevel,
      });
      setOpen(false);
      form.resetFields();
    } catch (error) {
      console.error("Failed to create learning item:", error);
    }
  };

  const handleCancel = () => {
    setOpen(false);
    form.resetFields();
  };

  return (
    <Modal
      title="Add Learning Item"
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
      <Form form={form} layout="vertical" name="learningItemForm">
        <Form.Item
          name="name"
          label="Name"
          rules={[{ required: true, message: "Please input the item name!" }]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          name="description"
          label="Description"
          rules={[{ required: true, message: "Please input the description!" }]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          name="category"
          label="Category"
          rules={[{ required: true, message: "Please select a category!" }]}
        >
          <Select placeholder="Select a category">
            <Option value="frontend">Frontend</Option>
            <Option value="backend">Backend</Option>
            <Option value="database">Database</Option>
          </Select>
        </Form.Item>
        <Form.Item
          name="priority"
          label="Priority"
          rules={[{ required: true, message: "Please select a priority!" }]}
        >
          <Select placeholder="Select a priority">
            <Option value="high">High</Option>
            <Option value="medium">Medium</Option>
            <Option value="low">Low</Option>
          </Select>
        </Form.Item>
        <Form.Item
          name="userLevel"
          label="User Level"
          rules={[{ required: true, message: "Please select a user level!" }]}
        >
          <Select placeholder="Select a user level">
            <Option value="beginner">Beginner</Option>
            <Option value="intermediate">Intermediate</Option>
            <Option value="advanced">Advanced</Option>
          </Select>
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default AddLearningItem;
