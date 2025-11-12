import { useState } from "react";
import type { InputProps } from "./types";
import * as S from "./styles";

const Input = ({
    name,
    label,
    required = false,
    disabled = false,
    placeholder,
    errorMessage,
    type = "text",
    value,
    onChange,
    customInputStyle,
    customLabelStyle,
    customIconStyle,
    showPlaceholderLabel = false,
}: InputProps) => {
    const [showPassword, setShowPassword] = useState(false);

    const togglePassword = () => setShowPassword((prev) => !prev);

    return (
        <S.Container>
            {label && (
                <S.Label style={customLabelStyle}>
                    {label}
                </S.Label>
            )}
            {showPlaceholderLabel && placeholder && (
                <S.PlaceholderLabel style={customLabelStyle}>
                    {placeholder}
                </S.PlaceholderLabel>
            )}
            <S.InputWrapper>
                <S.StyledInput
                    name={name}
                    required={required}
                    disabled={disabled}
                    placeholder={placeholder ?? ""}
                    type={type === "password" && !showPassword ? "password" : "text"}
                    value={value}
                    onChange={(e) => onChange(e.target.value)}
                    style={customInputStyle}
                />
                {type === "password" && (
                    <S.Icon
                        onClick={togglePassword}
                        style={customIconStyle}
                    >
                        {showPassword ? "🙈" : "👁️"}
                    </S.Icon>
                )}
                {type === "search" && (
                    <S.Icon style={customIconStyle}>
                        🔍
                    </S.Icon>
                )}
            </S.InputWrapper>
            {errorMessage && (
                <S.ErrorMessage>
                    {errorMessage}
                </S.ErrorMessage>
            )}
        </S.Container>
    );
};

export default Input;
export type { InputProps } from './types';
