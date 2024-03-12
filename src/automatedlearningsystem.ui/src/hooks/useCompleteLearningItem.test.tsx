import { describe, expect, it, vi } from "vitest";

import { act, renderHook } from "@testing-library/react";
import nock from "nock";
import { QueryClient } from "@tanstack/react-query";
import { useCompleteLearningItem } from "./useCompleteLearningItem";
import { queryClientWrapper } from "__tests__/common/utils";

vi.mock("src/common", () => {
  return {
    queryClient: new QueryClient(),
  };
});
vi.mock("src/stores/userStore", () => ({
  useAuthStore: () => ({
    User: {
      id: "123",
      email: "",
      firstName: "",
      lastName: "",
      password: "",
      role: "Admin",
    },
  }),
}));
import { queryClient } from "src/common";

describe("useCompleteLearningItem hook", () => {
  it("should call the complete user learning item endpoint", async () => {
    // Arrange

    const learningItemId = "learning-item-123";

    let called = 0;
    nock(`${import.meta.env.VITE_API_BASE}`)
      .defaultReplyHeaders({
        "access-control-allow-origin": "*",
        "access-control-allow-credentials": "true",
      })
      .intercept(`/api/user-learning-items/${learningItemId}`, "OPTIONS")
      .reply(200)
      .put(`/api/user-learning-items/${learningItemId}`)
      .reply(200, () => called++);

    queryClient.setQueryData(["learning-paths"], []);
    const Wrapper = queryClientWrapper(queryClient);
    const { result } = renderHook(() => useCompleteLearningItem(), {
      wrapper: Wrapper,
    });

    // Act
    await act(async () => await result.current.mutateAsync(learningItemId));

    // Assert
    expect(called).toBe(1);
    expect(
      queryClient.getQueryState(["learning-paths"])?.isInvalidated
    ).toBeTruthy();
  });
});
