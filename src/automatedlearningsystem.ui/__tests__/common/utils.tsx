import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ReactNode } from "react";
import { RouterProvider } from "react-router-dom";
import { vi } from "vitest";

interface Props {
  children: ReactNode;
}
export function queryClientWrapper(queryClient?: QueryClient | undefined) {
  return ({ children }: Props) => (
    <QueryClientProvider client={queryClient || new QueryClient()}>
      {children}
    </QueryClientProvider>
  );
}

export function routerProvider() {
  return () => <RouterProvider router={vi.fn() as any} />;
}

export var mockedUsers: User[] = [
  {
    firstName: "Syed",
    lastName: "Junaid",
    email: "syed@gmail.com",
    id: "1",
    password: "",
    role: "Student",
  },
  {
    firstName: "Sid",
    lastName: "Senati",
    email: "sid@senati.com",
    id: "2",
    password: "",
    role: "Admin",
  },
];
