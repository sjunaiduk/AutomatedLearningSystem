import { create } from "zustand";

interface UserStore {
  Authenticated: boolean;
  User: User | null;
  LoginUser: (email: string) => void;
  LogoutUser: () => void;
}
export const useAuthStore = create<UserStore>((set) => ({
  Authenticated: false,
  User: null,
  LoginUser: (email) =>
    set(() => ({ Authenticated: true, User: { Role: "Admin", Email: email } })),
  LogoutUser: () =>
    set(() => ({ Authenticated: false, Email: "", User: null })),
}));
