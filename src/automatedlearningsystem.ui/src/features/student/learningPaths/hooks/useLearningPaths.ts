import { useQuery } from "@tanstack/react-query";
import getLearningPathsService from "../services/learningPathsService";

export const useLearningPaths = (userId: string) => {
  return useQuery({
    queryKey: ["learning-paths", userId],
    queryFn: () => getLearningPathsService(userId).GetAll(),
  });
};
