export type Theme = {
  primary: string;
  primaryHover: string;
  primaryLight: string;
  secondary: string;
  secondaryHover: string;
  background: string;
  backgroundAlt: string;
  surface: string;
  surfaceHover: string;
  textPrimary: string;
  textSecondary: string;
  textTertiary: string;
  success: string;
  successLight: string;
  warning: string;
  warningLight: string;
  danger: string;
  dangerLight: string;
  info: string;
  infoLight: string;
  border: string;
  borderLight: string;
  shadow: string;
  gradient: string;
};

export const lightTokens: Theme = {
  // Primary colors - Blue theme
  primary: "#1976d2",
  primaryHover: "#1565c0",
  primaryLight: "#e3f2fd",
  
  // Secondary colors - Purple accent
  secondary: "#7c4dff",
  secondaryHover: "#651fff",
  
  // Backgrounds
  background: "#f5f7fa",
  backgroundAlt: "#ffffff",
  surface: "#ffffff",
  surfaceHover: "#f8f9fa",
  
  // Text colors
  textPrimary: "#1a1a1a",
  textSecondary: "#4a5568",
  textTertiary: "#718096",
  
  // Status colors
  success: "#10b981",
  successLight: "#d1fae5",
  warning: "#f59e0b",
  warningLight: "#fef3c7",
  danger: "#ef4444",
  dangerLight: "#fee2e2",
  info: "#3b82f6",
  infoLight: "#dbeafe",
  
  // Borders and shadows
  border: "#e2e8f0",
  borderLight: "#f1f5f9",
  shadow: "rgba(0, 0, 0, 0.1)",
  
  // Gradient
  gradient: "linear-gradient(135deg, #667eea 0%, #764ba2 100%)",
};

export const darkTokens: Theme = {
  // Primary colors - Orange/Blue theme for dark
  primary: "#60a5fa",
  primaryHover: "#3b82f6",
  primaryLight: "#1e3a5f",
  
  // Secondary colors - Purple accent
  secondary: "#a78bfa",
  secondaryHover: "#8b5cf6",
  
  // Backgrounds
  background: "#0f172a",
  backgroundAlt: "#1e293b",
  surface: "#1e293b",
  surfaceHover: "#334155",
  
  // Text colors
  textPrimary: "#f1f5f9",
  textSecondary: "#cbd5e1",
  textTertiary: "#94a3b8",
  
  // Status colors
  success: "#34d399",
  successLight: "#064e3b",
  warning: "#fbbf24",
  warningLight: "#78350f",
  danger: "#f87171",
  dangerLight: "#7f1d1d",
  info: "#60a5fa",
  infoLight: "#1e3a8a",
  
  // Borders and shadows
  border: "#334155",
  borderLight: "#475569",
  shadow: "rgba(0, 0, 0, 0.3)",
  
  // Gradient
  gradient: "linear-gradient(135deg, #667eea 0%, #764ba2 100%)",
};
