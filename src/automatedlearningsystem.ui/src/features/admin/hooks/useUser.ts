import { useQuery } from "@tanstack/react-query";
import { userService } from "../services/userService";

export const useUser = (userId: string) => {
  const { data } = useQuery({
    queryKey: ["users", userId],
    enabled: userId != undefined,
    queryFn: () => userService.Get(userId),
  });

  return {
    data,
  };
};
