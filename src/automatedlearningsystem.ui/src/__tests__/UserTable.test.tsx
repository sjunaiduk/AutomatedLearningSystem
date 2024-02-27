import { render } from "@testing-library/react";
import "@testing-library/jest-dom";
import UserTable from "src/features/admin/users/components/UserTable";

jest.mock("src/features/admin/users/hooks/useUpdateUser", () => ({
  useUpdateUser: () => ({
    mutate: jest.fn(),
  }),
}));

jest.mock("src/features/admin/users/hooks/useDeleteUser", () => ({
  useDeleteUser: () => ({
    mutate: jest.fn(),
  }),
}));

jest.mock("src/features/admin/users/hooks/useUsers", () => ({
  useUsers: () => ({
    data: [],
  }),
}));

// Tests
describe("Component rendering tests", () => {
  test("Renders UserTable component correctly", () => {
    window.matchMedia = jest.fn().mockImplementation(() => ({
      matches: false,
      addListener: jest.fn(),
      removeListener: jest.fn(),
      addEventListener: jest.fn(),
      removeEventListener: jest.fn(),
      dispatchEvent: jest.fn(),
    }));

    const { getByRole } = render(<UserTable />);
    expect(getByRole("table")).toBeInTheDocument();
  });
});
