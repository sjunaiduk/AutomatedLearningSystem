import React, { useState } from "react";
import { Space, Table } from "antd";
import { useUsers } from "../hooks/useUsers";
import EditUserModal from "./EditUserModal";

const { Column } = Table;

const UserTable: React.FC = () => {
  let { data } = useUsers();
  const [open, setOpen] = useState(false);
  const [user, setUser] = useState({} as User);
  return (
    <>
      <Table dataSource={data} rowKey={(record) => record.id}>
        <Column title="First Name" dataIndex="firstName" key="firstName" />
        <Column title="Last Name" dataIndex="lastName" key="lastName" />
        <Column title="Role" dataIndex="role" key="role" />
        <Column
          title="Action"
          key="action"
          render={(_: any, user: any) => (
            <Space size="middle">
              <a
                onClick={() => {
                  setUser(user);
                  setOpen(true);
                }}
              >
                Edit
              </a>
              <a>Delete</a>
            </Space>
          )}
        />
      </Table>
      <EditUserModal open={open} setOpen={setOpen} user={user} />
    </>
  );
};

export default UserTable;
