import type { CSSProperties } from "react";

export type CardProps = {
    title?: string;
    children: React.ReactNode;
    customStyle?: CSSProperties;
    onClick?: () => void;
};
