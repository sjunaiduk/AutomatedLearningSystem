import { Table } from "antd";
import { useState } from "react";
import { useDeleteUser } from "../features/admin/users/hooks/useDeleteUser";
import { useUsers } from "../features/admin/users/hooks/useUsers";

const DummyTable = () => {
  const columns = [
    {
      title: "Name",
      dataIndex: "name",
      key: "name",
    },
    {
      title: "Age",
      dataIndex: "age",
      key: "age",
    },
    {
      title: "Address",
      dataIndex: "address",
      key: "address",
    },
  ];

  const data = [
    {
      key: "1",
      name: "John Doe",
      age: 32,
      address: "New York No. 1 Lake Park",
    },
    {
      key: "2",
      name: "Jane Doe",
      age: 42,
      address: "London No. 1 Lake Park",
    },
    {
      key: "3",
      name: "Joe Doe",
      age: 22,
      address: "Sidney No. 1 Lake Park",
    },
  ];
  let { data: users } = useUsers();
  const [editModalOpen, setEditModalOpen] = useState(false);
  const [user, setUser] = useState({} as User);
  const { mutate: deleteUser } = useDeleteUser();

  console.log(
    users,
    editModalOpen,
    setEditModalOpen,
    user,
    setUser,
    deleteUser
  );

  return <Table columns={columns} dataSource={data} />;
};

export default DummyTable;
