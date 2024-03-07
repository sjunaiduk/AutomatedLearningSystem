import { BaseClient } from "./apiClient";

export const questionService = new BaseClient<Question[]>("/api/questions");
