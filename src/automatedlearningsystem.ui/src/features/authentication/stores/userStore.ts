import { create } from "zustand";
import { persist, createJSONStorage } from "zustand/middleware";

interface LoginStoreData {
  id: string;
  role: "Admin" | "Student";
  email: string;
  firstName: string;
  lastName: string;
}

interface UserStore {
  Authenticated: boolean;
  User: User | null;
  LoginUser: (loginData: LoginStoreData) => void;
  LogoutUser: () => void;
}
export const useAuthStore = create<UserStore>()(
  persist(
    (set) => ({
      Authenticated: false,
      User: null,
      LoginUser: (loginData) =>
        set(() => ({
          Authenticated: true,
          User: {
            ...loginData,
            password: "",
          },
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
