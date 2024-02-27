import { render, waitFor, screen } from "@testing-library/react";
import "@testing-library/jest-dom";
import { Navbar } from "../components/layout/Navbar";
import DummyTable from "../components/DummyTable";
// Mocks
jest.mock("../features/authentication/hooks/useLogout", () => ({
  useLogout: () => ({
    logout: jest.fn(),
  }),
}));

const mockDeleteMutationCall = jest.fn().mockReturnValue({
  mutate: jest.fn,
});
jest.mock("../features/admin/users/hooks/useDeleteUser", () => ({
  useDeleteUser: () => ({
    mutate: mockDeleteMutationCall,
  }),
}));
jest.mock("../features/admin/users/hooks/useUsers", () => ({
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

  test("Renders UserTable component correctly", async () => {
    window.matchMedia = jest.fn().mockImplementation(() => ({
      matches: false,
      addListener: jest.fn(),
      removeListener: jest.fn(),
      addEventListener: jest.fn(),
      removeEventListener: jest.fn(),
      dispatchEvent: jest.fn(),
    }));

    await waitFor(() => {
      const { getByRole } = render(<DummyTable />);
      expect(getByRole("table")).toBeInTheDocument();
    });
  });
});
