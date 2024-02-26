/// <reference types="vitest" />
import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

// https://vitejs.dev/config/
export default defineConfig(({ mode }) => ({
  plugins: [react()],
  test: {
    globals: true,
    environment: "jsdom",
    setupFiles: ["./vitest.setup.ts"],
  },
  build: {
    outDir: "../AutomatedLearningSystem.Api/wwwroot/client",
    emptyOutDir: true,
  },

  base: mode === "production" ? "client/" : "/",
}));
