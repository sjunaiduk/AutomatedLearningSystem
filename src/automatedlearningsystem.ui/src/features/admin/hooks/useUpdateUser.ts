import { useMutation } from "@tanstack/react-query";
import { queryClient } from "../../../main";
import { userService } from "../services/userService";

export const useUpdateUser = () =>
  useMutation({
    mutationFn: (updatedUser: User) => {
      return userService.Update(updatedUser.id, updatedUser);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["users"],
      });
    },
  });
