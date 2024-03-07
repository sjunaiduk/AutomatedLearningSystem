import { render, waitFor } from "@testing-library/react";
import { describe, expect, it, vi } from "vitest";
import UserTable from "src/components/users/UserTable";
import { mockedUsers, queryClientWrapper } from "__tests__/common/utils";
import nock from "nock";

// Arrange Mock Modules
vi.mock("src/hooks/useUpdateUser", () => ({
  useUpdateUser: () => ({
    mutate: vi.fn(),
  }),
}));

vi.mock("src/hooks/useDeleteUser", () => ({
  useDeleteUser: () => ({
    mutate: vi.fn(),
  }),
}));

describe("users", () => {
  it("should render a table of users", async () => {
    // Arrange
    nock(import.meta.env.VITE_API_BASE)
      .defaultReplyHeaders({
        "access-control-allow-origin": "*",
        "access-control-allow-credentials": "true",
      })
      .get("/api/users")
      .reply(200, mockedUsers);

    const Wrapper = queryClientWrapper();

    // Act
    const { getByRole } = render(
      <Wrapper>
        <UserTable />
      </Wrapper>
    );

    // Assert
    await waitFor(() => {
      var table = getByRole("table");
      expect(table).toBeInTheDocument();
      expect(table).toHaveTextContent(mockedUsers[0].firstName);
    });
  });
});
