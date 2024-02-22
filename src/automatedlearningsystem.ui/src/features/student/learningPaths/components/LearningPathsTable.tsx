import { useLearningPaths } from "../hooks/useLearningPaths";
import { useAuthStore } from "../../../authentication/stores/userStore";
import { Table } from "antd";
import Column from "antd/es/table/Column";
import ColumnGroup from "antd/es/table/ColumnGroup";

const LearningPathsTable = () => {
  const { User } = useAuthStore();
  const { data } = useLearningPaths(User!.id);

  return (
    <Table
      dataSource={
        (data?.length && data[0].learningItems) || ([] as LearningItem[])
      }
    >
      <ColumnGroup title="Learning Path Name">
        <Column title="topic"></Column>
        <Column title="category"></Column>
        <Column title="completed"></Column>
      </ColumnGroup>
    </Table>
  );
};

export default LearningPathsTable;
