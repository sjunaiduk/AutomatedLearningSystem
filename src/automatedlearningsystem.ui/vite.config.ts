import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import path from "path";
// https://vitejs.dev/config/
export default defineConfig(({ mode }) => ({
  plugins: [react()],
  build: {
    outDir: "../AutomatedLearningSystem.Api/wwwroot/client",
    emptyOutDir: true,
  },
  resolve: {
    alias: [
      {
        find: "src",
        replacement: path.resolve(__dirname, "./src"),
      },
    ],
  },
  base: mode === "production" ? "client/" : "/",
}));
