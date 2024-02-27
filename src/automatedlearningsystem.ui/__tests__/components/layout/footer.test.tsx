import { describe, it, expect } from "vitest";
import { render } from "@testing-library/react";
import FooterComponent from "src/components/layout/Footer";

describe("Footer", () => {
  it("should render the footer", () => {
    const { getByTestId } = render(<FooterComponent />);
    const footer = getByTestId("footer");

    expect(footer).toHaveTextContent("Ant");
  });
});
