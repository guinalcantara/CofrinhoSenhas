import type { ButtonProps } from "./types";
import * as S from "./styles";

const Button = ({
    variant = "ok",
    type = "button",
    onClick,
    style,
    label,
    disabled = false,
}: ButtonProps) => {
    return (
        <S.StyledButton
            type={type}
            $variant={variant}
            style={style}
            onClick={onClick}
            disabled={disabled}
        >
            {label || variant.toUpperCase()}
        </S.StyledButton>
    );
};

export default Button;
export type { ButtonProps } from './types';
