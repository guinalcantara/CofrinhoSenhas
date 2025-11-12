import { type Theme, lightTokens } from "../styles/tokens";
import { useState } from "react";

export function useTheme(initial: Theme = lightTokens) {
  const [theme, setTheme] = useState<Theme>(initial);

  return { theme, setTheme };
}
