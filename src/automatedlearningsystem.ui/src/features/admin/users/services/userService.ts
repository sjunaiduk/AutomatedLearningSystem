import { BaseClient } from "../../../../services/apiClient";

export const userService = new BaseClient<User>("/api/users");
