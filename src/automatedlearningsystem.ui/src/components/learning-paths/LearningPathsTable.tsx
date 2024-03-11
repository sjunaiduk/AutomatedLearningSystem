import { Checkbox, Table } from "antd";
import { CheckboxChangeEvent } from "antd/es/checkbox/Checkbox";
interface Props {
  learningPaths: LearningPath[];
}
const LearningPathsTable = ({ learningPaths }: Props) => {
  return (
    <>
      {learningPaths?.map((learningPath) => (
        <div key={learningPath.id} style={{ marginBottom: "20px" }}>
          <h2>{learningPath.name}</h2>
          <Table
            dataSource={learningPath.userLearningItems}
            rowKey={(record) => record.id}
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
                  onChange={(event: CheckboxChangeEvent) =>
                    console.log(
                      "sending complete request for learning item with id",
                      learningItem.id,
                      event.target.checked
                    )
                  }
                  defaultChecked={completed}
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
