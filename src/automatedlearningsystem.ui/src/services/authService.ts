import { client } from "./apiClient";

class AuthService {
  constructor() {}

  async Login(data: LoginData) {
    var res = await client.post<LoginResponse>("/auth/login", data);
    return res.data;
  }

  async Logout() {
    await client.get("/auth/logout");
  }
}

export default new AuthService();
