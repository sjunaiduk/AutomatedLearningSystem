import {
  QueryClient,
  QueryClientConfig,
  QueryClientProvider,
} from "@tanstack/react-query";
import { ReactNode } from "react";

interface Props {
  children: ReactNode;
}
export function queryClientWrapper(config?: QueryClientConfig | undefined) {
  const queryClient = new QueryClient(config);
  return ({ children }: Props) => (
    <QueryClientProvider client={queryClient}>{children}</QueryClientProvider>
  );
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
