import { QueryClient } from "@tanstack/react-query";
import { renderHook, waitFor } from "@testing-library/react";
import nock from "nock";
import { describe, expect, it, vi } from "vitest";

import { useAddUser } from "./useAddUser";
import { queryClientWrapper } from "__tests__/common/utils";
import { queryClient } from "src/common";

vi.mock("src/common", () => {
  return {
    queryClient: new QueryClient(),
  };
});

describe("userAddUser hook", () => {
  it("should add the user and update the query cache", async () => {
    // Arrange
    var calls = 0;
    var createUserRequest: CreateUserRequest = {
      email: "new@gmail.com",
      firstName: "newFirstName",
      lastName: "newLastName",
      password: "newPassword",
      role: "Student",
    };

    queryClient.setQueryData(["users"], []);
    const Wrapper = queryClientWrapper(queryClient);
    nock(import.meta.env.VITE_API_BASE)
      .defaultReplyHeaders({
        "access-control-allow-origin": "*",
        "access-control-allow-credentials": "true",
      })
      .post("/api/users")
      .reply(201, () => calls++);

    // Act
    const { result } = renderHook(() => useAddUser(createUserRequest), {
      wrapper: Wrapper,
    });

    result.current.mutate();

    // Assert

    await waitFor(() => {
      expect(result.current.isSuccess).toBeTruthy();
      expect(calls).toBe(1);
      expect(result.current.data).not.toBeUndefined();
      expect(queryClient.getQueryState(["users"])?.isInvalidated).toBeTruthy();
    });
    // await waitFor(
    //   () =>
    //     expect(
    //       queryClient.getQueryState(["users"])?.isInvalidated
    //     ).toBeTruthy(),
    //   {
    //     timeout: 10000,
    //   }
    // );
  });
});
