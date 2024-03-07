import React, { useState } from "react";
import { Button, Space, Table } from "antd";
import { useUsers } from "src/hooks/users/useUsers";
import EditUserModal from "./EditUserModal";
import { useDeleteUser } from "src/hooks/users/useDeleteUser";
import AddUserModal from "./AddUserModal";

const { Column } = Table;

const UserTable: React.FC = () => {
  let { data: users } = useUsers();
  const [editModalOpen, setEditModalOpen] = useState(false);
  const [addModalOpen, setAddModalOpen] = useState(false);
  const [user, setUser] = useState({} as User);
  const { mutate: deleteUser } = useDeleteUser();
  return (
    <>
      <Button onClick={() => setAddModalOpen(!addModalOpen)}>Add User</Button>
      <Table dataSource={users} rowKey={(record) => record.id}>
        <Column title="First Name" dataIndex="firstName" key="firstName" />
        <Column title="Last Name" dataIndex="lastName" key="lastName" />
        <Column title="Role" dataIndex="role" key="role" />
        <Column
          title="Action"
          key="action"
          render={(_: any, user: User) => (
            <Space size="middle">
              <a
                onClick={() => {
                  setUser(user);
                  setEditModalOpen(true);
                }}
              >
                Edit
              </a>
              <a
                onClick={() => {
                  confirm(
                    `About to delete ${user.firstName} ${user.lastName}. Click 'OK' to proceed`
                  ) && deleteUser(user.id);
                }}
              >
                Delete
              </a>
            </Space>
          )}
        />
      </Table>
      <EditUserModal
        open={editModalOpen}
        setOpen={setEditModalOpen}
        user={user}
      />
      <AddUserModal open={addModalOpen} setOpen={setAddModalOpen} />
    </>
  );
};

export default UserTable;
