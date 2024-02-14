import { create } from "zustand";

interface UserStore {
  Authenticated: boolean;
  Email: string;
  Authenticate: (email: string) => void;
}
export const useAuthStore = create<UserStore>((set) => ({
  Authenticated: false,
  Email: "",
  Authenticate: (email) => set(() => ({ Authenticated: true, Email: email })),
}));
