import "@testing-library/jest-dom";
import { vi } from "vitest";
import "./src/global.d.ts";

globalThis.window.matchMedia = vi.fn().mockImplementation((query) => ({
  matches: false, // or true, depending on what you need
  addListener: vi.fn(),
  removeListener: vi.fn(),
  addEventListener: vi.fn(),
  removeEventListener: vi.fn(),
  dispatchEvent: vi.fn(),
  getComputedStyle: vi.fn(),
}));

globalThis.window.getComputedStyle = vi
  .fn()
  .mockImplementation((element, pseudoElement) => {
    return {
      display: "block", // Example property
      height: "0", // Example property
      width: "0",
    };
  });
