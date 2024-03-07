import { useQuery } from "@tanstack/react-query";
import { questionService } from "src/services/questionService";

export const useQuestions = () =>
  useQuery({
    queryKey: ["questions"],
    queryFn: questionService.GetAll,
  });
