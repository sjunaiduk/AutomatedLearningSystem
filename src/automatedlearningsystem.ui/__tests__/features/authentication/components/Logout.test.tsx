import { QueryClient } from "@tanstack/react-query";
import { fireEvent, render, screen, waitFor } from "@testing-library/react";
import { queryClientWrapper } from "__tests__/common/utils";
import nock from "nock";
import { RouterProvider, createMemoryRouter } from "react-router-dom";
import { routerConfig } from "src/routes";
import { describe, expect, it, vi } from "vitest";

vi.mock("src/main", () => ({
  ...new QueryClient(),
}));

describe("Logout Button", () => {
  it("should call the logout backend when logout button is clicked with valid values and redirect to homepage", async () => {
    // Arrange
    const loginResponse: LoginResponse = {
      email: "",
      firstName: "",
      id: "1",
      lastName: "",
      role: "Admin",
    };
    const Wrapper = queryClientWrapper();
    let loginCalled = 0;
    nock(import.meta.env.VITE_API_BASE)
      .defaultReplyHeaders({
        "access-control-allow-origin": "*",
        "access-control-allow-credentials": "true",
      })
      .post("/auth/login")
      .reply(200, () => {
        loginCalled++;
        return loginResponse;
      });

    let logoutCalled = 0;
    nock(import.meta.env.VITE_API_BASE)
      .defaultReplyHeaders({
        "access-control-allow-origin": "*",
        "access-control-allow-credentials": "true",
      })
      .get("/auth/logout")
      .reply(200, () => logoutCalled++);

    const mockRouter = createMemoryRouter(routerConfig, {
      initialEntries: ["/login"],
    });
    const { getByPlaceholderText, getByTestId } = render(
      <Wrapper>
        <RouterProvider router={mockRouter} />
      </Wrapper>
    );

    // Act
    fireEvent.change(getByPlaceholderText("Email"), {
      target: { value: "test@example.com" },
    });
    fireEvent.change(getByPlaceholderText("Password"), {
      target: { value: "password" },
    });

    fireEvent.click(getByTestId("login-button"));
    await screen.findByTestId("logout-button");
    expect(loginCalled).toBe(1);
    fireEvent.click(getByTestId("logout-button"));

    // Assert

    await waitFor(() => {
      expect(loginCalled).toBe(1);
      expect(logoutCalled).toBe(1);
      expect(screen.queryByTestId("login-nav-button")).toBeInTheDocument();
      expect(window.location.pathname).toBe("/");
    });
  });
});
