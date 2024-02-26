import { render, waitFor } from "@testing-library/react";
import { describe, expect, it, vi } from "vitest";
import UserTable from "../../../../../src/features/admin/users/components/UserTable";
import React from "react";
import * as useUsers from "../../../../../src/features/admin/users/hooks/useUsers";
import * as useDeleteUser from "../../../../../src/features/admin/users/hooks/useDeleteUser";
import * as useUpdateUser from "../../../../../src/features/admin/users/hooks/useUpdateUser";

const mockUsers: User[] = [
  {
    firstName: "Sid",
    lastName: "Senati",
    id: "",
    email: "",
    password: "",
    role: "Admin",
  },
];
describe("users", () => {
  const useUsersSpy = vi.spyOn(useUsers, "useUsers");
  //const useDeleteUserSpy = vi.spyOn(useDeleteUser, "useDeleteUser");
  //const useUpdateUserSpy = vi.spyOn(useUpdateUser, "useUpdateUser");

  // useDeleteUserSpy.mockReturnValue({
  //   mutate: vi.fn(),
  // });
  // useUpdateUserSpy.mockReturnValue({
  //   mutate: vi.fn(),
  // });
  useUsersSpy.mockReturnValue({
    data: mockUsers,
  });
  it("should render a table of users", async () => {
    render(<UserTable />);
  });
});
