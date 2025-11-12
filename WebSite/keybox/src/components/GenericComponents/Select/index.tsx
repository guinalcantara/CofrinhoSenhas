import type { SelectProps } from "./types";
import * as S from "./styles";

const Select = ({
    name,
    value,
    options,
    onChange,
    placeholder,
    disabled = false,
    className = "",
    customStyle,
    label,
}: SelectProps) => {
    const handleChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        onChange(e.target.value);
    };

    const selectValue = String(value);

    return (
        <S.Container>
            {label && <S.Label>{label}</S.Label>}
            <S.StyledSelect
                style={customStyle}
                name={name}
                value={selectValue}
                onChange={handleChange}
                disabled={disabled}
                className={className}
            >
                {placeholder && (
                    <S.Option key={0} value="0">{placeholder}</S.Option>
                )}
                {options.map((opt) => (
                    <S.Option key={opt.value} value={opt.value}>
                        {opt.label}
                    </S.Option>
                ))}
            </S.StyledSelect>
        </S.Container>
    );
};

export default Select;
export type { SelectProps, SelectOption } from './types';
