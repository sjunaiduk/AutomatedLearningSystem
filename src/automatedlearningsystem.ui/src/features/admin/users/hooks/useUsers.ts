import { useQuery } from "@tanstack/react-query";
import { userService } from "../services/userService";

export const useUsers = () => {
  const query = useQuery({
    queryKey: ["users"],
    queryFn: userService.GetAll,
  });

  return { data: query.data };
};
