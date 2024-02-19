import { useMutation } from "@tanstack/react-query";
import { queryClient } from "../../../main";
import { userService } from "../services/userService";

export const useDeleteUser = () =>
  useMutation({
    mutationFn: (userId: string) => {
      return userService.Delete(userId);
    },
    onSuccess: () => {
      console.log("successfuly deleted user");

      queryClient.invalidateQueries({
        queryKey: ["users"],
      });
    },
  });
