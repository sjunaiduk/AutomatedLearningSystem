import { render, waitFor } from "@testing-library/react";
import { describe, expect, it, vi } from "vitest";
import UserTable from "src/features/admin/users/components/UserTable";

const mockedUsers: User[] = [
  {
    email: "myemail@gmail.com",
    firstName: "junaid",
    id: "",
    lastName: "",
    password: "",
    role: "Admin",
  },
];

vi.mock("src/features/admin/users/hooks/useUpdateUser", () => ({
  useUpdateUser: () => ({
    mutate: vi.fn(),
  }),
}));

vi.mock("src/features/admin/users/hooks/useDeleteUser", () => ({
  useDeleteUser: () => ({
    mutate: vi.fn(),
  }),
}));

vi.mock("src/features/admin/users/hooks/useUsers", () => ({
  useUsers: () => ({
    data: mockedUsers,
  }),
}));

describe("users", () => {
  it("should render a table of users", async () => {
    const { getByRole, queryByText } = render(<UserTable />);
    await waitFor(() => {
      var table = getByRole("table");
      expect(table).toBeInTheDocument();
      expect(table).toHaveTextContent("junaid");
      expect(queryByText("sam")).toBeNull();
    });
  });
});
