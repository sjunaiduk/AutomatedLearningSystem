import React, { useEffect, useState } from "react";
import { Button, Table } from "antd";
import { client } from "src/services/apiClient";
import AddLearningItem from "./AddLearningItem";

const LearningItemsTable: React.FC = () => {
  const [learningItems, setLearningItems] = useState<LearningItem[]>([]);
  const [addModalOpen, setAddModalOpen] = useState(false);

  useEffect(() => {
    async function load() {
      var data = await client.get("/api/learning-items");
      setLearningItems(data.data);
    }
    load();
  }, [addModalOpen]);

  return (
    <>
      <Button
        type="primary"
        style={{
          marginBottom: "1rem",
        }}
        onClick={() => setAddModalOpen(!addModalOpen)}
      >
        Add Learning Item
      </Button>
      <Table dataSource={learningItems} rowKey={(record) => record.id}>
        <Table.Column title="Name" dataIndex="name" key="name" />
        <Table.Column title="Category" dataIndex="category" key="category" />
        <Table.Column title="Priority" dataIndex="priority" key="priority" />
        <Table.Column
          title="User Level"
          dataIndex="userLevel"
          key="userLevel"
        />
      </Table>

      <AddLearningItem open={addModalOpen} setOpen={setAddModalOpen} />
    </>
  );
};

export default LearningItemsTable;
