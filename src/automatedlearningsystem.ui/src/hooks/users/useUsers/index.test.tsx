import { describe, expect, it } from "vitest";
import nock from "nock";
import { renderHook, waitFor } from "@testing-library/react";
import { useUsers } from "src/hooks/users/useUsers";
import { mockedUsers, queryClientWrapper } from "__tests__/common/utils";

describe("useUsers() hook", () => {
  it("should successfuly return data from the users endpoint", async () => {
    // Arrange
    const wrapper = queryClientWrapper();
    nock(import.meta.env.VITE_API_BASE)
      .defaultReplyHeaders({
        "access-control-allow-origin": "*",
        "access-control-allow-credentials": "true",
      })
      .get("/api/users")
      .reply(200, mockedUsers);

    // Act
    const { result } = renderHook(() => useUsers(), { wrapper });

    // Assert
    await waitFor(() => {
      const { data, isSuccess } = result.current;
      expect(data).toStrictEqual(mockedUsers);
      expect(isSuccess).toBeTruthy();
    });
  });
});
