import React, { useState } from "react";
import { Button, Popconfirm, Space, Table, message } from "antd";
import { useUsers } from "src/hooks/users/useUsers";
import EditUserModal from "./EditUserModal";
import { useDeleteUser } from "src/hooks/users/useDeleteUser";
import AddUserModal from "./AddUserModal";

const { Column } = Table;

const UserTable: React.FC = () => {
  let { data: users } = useUsers();
  const [editModalOpen, setEditModalOpen] = useState(false);
  const [addModalOpen, setAddModalOpen] = useState(false);
  const [userToEdit, setUserToEdit] = useState({} as User);
  const { mutate: deleteUser, data } = useDeleteUser();
  console.log(data);

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
                  setUserToEdit(user);
                  setEditModalOpen(true);
                }}
              >
                Edit
              </a>
              <Popconfirm
                title="Delete the user"
                description="Are you sure to delete this user?"
                onConfirm={() => {
                  deleteUser(user.id);
                  message.success("Deleted");
                }}
                okText="Yes"
                cancelText="No"
              >
                <a>Delete</a>
              </Popconfirm>
            </Space>
          )}
        />
      </Table>
      <EditUserModal
        open={editModalOpen}
        setOpen={setEditModalOpen}
        user={userToEdit}
      />
      <AddUserModal open={addModalOpen} setOpen={setAddModalOpen} />
    </>
  );
};

export default UserTable;
