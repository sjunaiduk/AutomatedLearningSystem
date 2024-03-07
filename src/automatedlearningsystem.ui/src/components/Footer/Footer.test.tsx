import { describe, it, expect } from "vitest";
import { render } from "@testing-library/react";
import FooterComponent from "src/components/Footer/Footer";

describe("Footer", () => {
  it("should render the footer", () => {
    // Act
    const { getByTestId } = render(<FooterComponent />);
    const footer = getByTestId("footer");

    // Assert
    expect(footer).toHaveTextContent("Ant");
  });
});
