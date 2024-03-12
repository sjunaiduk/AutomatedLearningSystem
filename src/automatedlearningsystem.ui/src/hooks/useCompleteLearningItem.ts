import { useMutation } from "@tanstack/react-query";
import { queryClient } from "src/common";
import { client } from "src/services/apiClient";
import { useAuthStore } from "src/stores/userStore";

const completeUserLearningItem = (userLearningItemId: string) =>
  client
    .put(`/api/user-learning-items/${userLearningItemId}`)
    .then((res) => res.data);

export const useCompleteLearningItem = () => {
  const User = useAuthStore((state) => state.User);
  return useMutation({
    mutationFn: (userLearningItemId: string) =>
      completeUserLearningItem(userLearningItemId),
    onSuccess: () => {
      console.log(`invalidating 'learning-paths, ${User?.id}`);
      queryClient.invalidateQueries({
        queryKey: ["learning-paths"],
      });
    },
  });
};
