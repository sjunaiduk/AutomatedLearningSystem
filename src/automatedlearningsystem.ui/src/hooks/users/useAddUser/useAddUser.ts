import { useMutation } from "@tanstack/react-query";
import { queryClient } from "src/common";
import { userService } from "src/services/userService";

export const useAddUser = (request: CreateUserRequest) =>
  useMutation({
    mutationFn: () => userService.Post<CreateUserRequest>(request),
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["users"],
      });
    },
  });
