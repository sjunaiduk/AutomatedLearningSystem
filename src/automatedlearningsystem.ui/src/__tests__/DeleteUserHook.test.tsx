import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { renderHook } from "@testing-library/react";
import * as useDeleteUsers from "src/features/admin/users/hooks/useDeleteUser";

jest.mock("../main", () => ({
  invalidateQueries: jest.fn(),
}));

describe("x", () => {
  test("useDeleteUserHook", () => {
    jest.spyOn(useDeleteUsers, "useDeleteUser");

    const queryClient = new QueryClient();
    const wrapper = ({ children }: any) => (
      <QueryClientProvider client={queryClient}>{children}</QueryClientProvider>
    );
    const { result } = renderHook(() => useDeleteUsers.useDeleteUser(), {
      wrapper,
    });

    jest.spyOn(result.current, "mutate");
    result.current.mutate("userid");
    expect(result.current.mutate).toHaveBeenCalledTimes(1);
  });
});
