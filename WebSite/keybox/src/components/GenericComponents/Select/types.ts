import type { CSSProperties } from "react";

export interface SelectOption {
    value: string | number;
    label: string;
}

export interface SelectProps {
    name: string;
    value: string | number | string[];
    options: SelectOption[];
    onChange: (value: string | string[]) => void;
    placeholder?: string;
    disabled?: boolean;
    className?: string;
    customStyle?: CSSProperties;
    label?: string;
}
