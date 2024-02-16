import { create } from "zustand";
import { persist, createJSONStorage } from "zustand/middleware";

interface UserStore {
  Authenticated: boolean;
  User: User | null;
  LoginUser: (email: string) => void;
  LogoutUser: () => void;
}
export const useAuthStore = create<UserStore>()(
  persist(
    (set) => ({
      Authenticated: false,
      User: null,
      LoginUser: (email) =>
        set(() => ({
          Authenticated: true,
          User: { Role: "Admin", Email: email },
        })),
      LogoutUser: () =>
        set(() => ({ Authenticated: false, Email: "", User: null })),
    }),
    {
      name: "als-auth-storage", // name of the item in the storage (must be unique)
      storage: createJSONStorage(() => sessionStorage), // (optional) by default, 'localStorage' is used
    }
  )
);
