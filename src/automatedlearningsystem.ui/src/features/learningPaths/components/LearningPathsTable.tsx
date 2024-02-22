import { Checkbox, Table } from "antd";
import { useLearningPaths } from "../hooks/useLearningPaths";
import { useAuthStore } from "../../authentication/stores/userStore";

const LearningPathsTable = () => {
  const { User } = useAuthStore();
  const { data: learningPaths } = useLearningPaths(User!.id);

  return (
    <>
      {learningPaths?.map((learningPath) => (
        <div key={learningPath.id} style={{ marginBottom: "20px" }}>
          <h2>{learningPath.name}</h2>
          <Table dataSource={learningPath.userLearningItems}>
            <Table.Column title="Name" dataIndex="name" key="name" />
            <Table.Column
              title="Category"
              dataIndex="category"
              key="category"
            />
            <Table.Column
              title="Completed"
              dataIndex="completed"
              key="completed"
              render={(completed) => <Checkbox defaultChecked={completed} />}
            />
          </Table>
        </div>
      ))}
    </>
  );
};

export default LearningPathsTable;
