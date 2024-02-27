/// <reference types="vitest" />
import { defineConfig } from "vite";
import path from "path";
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
  resolve: {
    alias: {
      src: path.resolve(__dirname, "src"),
      __tests__: path.resolve(__dirname, "./__tests__"),
    },
  },
  base: mode === "production" ? "client/" : "/",
}));
