import { useMutation } from "@tanstack/react-query";
import getLearningPathsService from "../services/learningPathsService";
import { queryClient } from "../main";

export const useGenerateLearningPaths = (userId: string) => {
  return useMutation({
    mutationFn: (requestData: GenerateLearningPathRequest) =>
      getLearningPathsService(userId).Post(requestData),
    onSuccess: () => {
      console.log("Generate learning path successful");
      queryClient.invalidateQueries({
        queryKey: ["learning-paths", userId],
      });
    },
    onError: (error) => console.log(error),
  });
};
