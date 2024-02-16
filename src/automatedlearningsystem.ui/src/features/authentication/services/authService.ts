import { client } from "../../../services/apiClient";

class AuthService {
  constructor() {}

  async Login(data: LoginData) {
    await client.post("/auth/login", data);
  }

  async Logout() {
    await client.get("/auth/logout");
  }
}

export default new AuthService();
