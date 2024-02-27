import { render, waitFor, screen } from "@testing-library/react";
import "@testing-library/jest-dom";
import { Navbar } from "src/components/layout/Navbar";

jest.mock("src/features/authentication/hooks/useLogout", () => ({
  useLogout: () => ({
    logout: jest.fn(),
  }),
}));

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

jest.mock("react-router-dom", () => ({
  ...jest.requireActual("react-router-dom"),
  useNavigate: jest.fn(),
}));

// Tests
describe("Component rendering tests", () => {
  test("Renders Navbar component correctly", async () => {
    render(<Navbar />);
    await waitFor(() => {
      expect(screen.getByText("Login")).toBeInTheDocument();
      expect(screen.queryByText("Users")).toBeNull();
    });
  });
});
