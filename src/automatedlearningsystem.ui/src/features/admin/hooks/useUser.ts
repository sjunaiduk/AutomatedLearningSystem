import { useQuery } from "@tanstack/react-query";
import { userService } from "../services/userService";

export const useUser = (userId: string) => {
  return useQuery({
    queryKey: ["users", userId],
    queryFn: () => userService.Get(`/api/users/${userId}`),
  });
};
