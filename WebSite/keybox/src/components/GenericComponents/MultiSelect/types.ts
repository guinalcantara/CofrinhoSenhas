export interface MultiSelectOption {
    value: string | number;
    label: string;
}

export interface MultiSelectProps {
    name?: string;
    value: (string | number)[];
    options: MultiSelectOption[];
    onChange: (value: (string | number)[]) => void;
    placeholder?: string;
    disabled?: boolean;
    className?: string;
    label?: string;
    searchable?: boolean;
}
