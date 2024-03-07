import { renderHook, waitFor } from "@testing-library/react";
import nock from "nock";
import { describe, expect, it } from "vitest";
import { useQuestions } from "./useQuestions";
import { queryClientWrapper } from "__tests__/common/utils";

describe("useQuestions hook", () => {
  it("should return questions", async () => {
    // Arrange
    const questions: Question[] = [
      {
        id: "1",
        category: "Backend",
        description: "This is my question",
      },
    ];
    const QueryClientWrapper = queryClientWrapper();
    nock(import.meta.env.VITE_API_BASE)
      .defaultReplyHeaders({
        "access-control-allow-origin": "*",
        "access-control-allow-credentials": "true",
      })
      .get("/api/questions")
      .reply(200, questions);

    // Act
    const { result } = renderHook(useQuestions, {
      wrapper: QueryClientWrapper,
    });

    // Assert
    await waitFor(() => expect(result.current.data).toEqual(questions));
  });
});
