import { BaseClient } from "../../../services/apiClient";

export default function getLearningPathsService(userId: string) {
  console.log(`User id : ${userId}`);

  console.log(`/api/users/${userId}/learning-paths`);

  return new BaseClient<LearningPath>(`/api/users/${userId}/learning-paths`);
}
