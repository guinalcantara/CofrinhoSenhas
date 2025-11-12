import type { ReactNode, CSSProperties } from "react";

export interface FormFieldProps {
    label?: string;
    required?: boolean;
    children: ReactNode;
    error?: string;
    customStyle?: CSSProperties;
}
