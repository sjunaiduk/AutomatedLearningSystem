import { describe, it, expect } from "vitest";
import { render, screen } from "@testing-library/react";
import FooterComponent from "../../../src/components/layout/Footer";
import React from "react";

describe("Footer", () => {
  it("should render the footer", () => {
    const { getByTestId } = render(<FooterComponent />);
    const footer = getByTestId("footer");

    expect(footer).toHaveTextContent("Ant");
  });
});
