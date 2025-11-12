import type { CSSProperties } from "react";

export type InputProps = {
    name?: string;
    label?: string;
    required?: boolean;
    disabled?: boolean;
    placeholder?: string;
    errorMessage?: string;
    type?: "text" | "password" | "search";
    value: string;
    onChange: (value: string) => void;
    customInputStyle?: CSSProperties;
    customLabelStyle?: CSSProperties;
    customIconStyle?: CSSProperties;
    showPlaceholderLabel?: boolean;
};
