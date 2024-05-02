import { Checkbox, Table } from "antd";
import Title from "antd/es/typography/Title";
import { useCompleteLearningItem } from "src/hooks/useCompleteLearningItem";
interface Props {
  learningPaths: LearningPath[];
}
const LearningPathsTable = ({ learningPaths }: Props) => {
  const { mutate } = useCompleteLearningItem();
  return (
    <>
      {learningPaths?.map((learningPath) => (
        <div key={learningPath.id} style={{ marginBottom: "20px" }}>
          <Title level={2}>{learningPath.name}</Title>
          <Table
            dataSource={learningPath.userLearningItems}
            rowKey={(record) => record.id}
            rowClassName={(record) => {
              if (record.completed) {
                return "row-completed";
              }
              return "";
            }}
          >
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
              render={(completed, learningItem: LearningItem) => (
                <Checkbox
                  onChange={() => mutate(learningItem.id)}
                  defaultChecked={completed}
                  disabled={learningItem.completed}
                />
              )}
            />
          </Table>
        </div>
      ))}
    </>
  );
};

export default LearningPathsTable;
