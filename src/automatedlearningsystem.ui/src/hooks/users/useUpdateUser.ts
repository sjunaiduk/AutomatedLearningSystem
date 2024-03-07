import { useMutation } from "@tanstack/react-query";
import { queryClient } from "src/common";
import { userService } from "../../services/userService";

export const useUpdateUser = () => {
  const mutation = useMutation({
    mutationFn: (updatedUser: User) => {
      return userService.Update<User>(updatedUser.id, updatedUser);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["users"],
      });
    },
  });

  return {
    mutate: mutation.mutate,
  };
};
