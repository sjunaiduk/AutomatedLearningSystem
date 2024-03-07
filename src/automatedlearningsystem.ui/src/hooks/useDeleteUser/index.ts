import { useMutation } from "@tanstack/react-query";
import { queryClient } from "src/common";
import { userService } from "../../services/userService";

export const useDeleteUser = () => {
  const mutation = useMutation({
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

  return {
    mutate: mutation.mutate,
  };
};
