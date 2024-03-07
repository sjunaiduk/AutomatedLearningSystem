import { BaseClient } from "./apiClient";

export const userService = new BaseClient<User>("/api/users");
