import type { CSSProperties } from "react";

export type ButtonProps = {
    variant?: "ok" | "cancelar" | "excluir";
    type?: "button" | "submit" | "reset";
    onClick?: () => void;
    style?: CSSProperties;
    label?: string;
    disabled?: boolean;
};
