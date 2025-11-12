import type { CheckboxProps } from "./types";
import * as S from "./styles";

const Checkbox = ({ label, checked, onChange, disabled = false }: CheckboxProps) => {
    const handleChange = () => {
        if (!disabled) {
            onChange(!checked);
        }
    };

    return (
        <S.Container>
            <S.HiddenCheckbox
                checked={checked}
                onChange={handleChange}
                disabled={disabled}
            />
            <S.StyledCheckbox $checked={checked} $disabled={disabled}>
                <svg viewBox="0 0 24 24">
                    <polyline points="20 6 9 17 4 12" fill="none" stroke="currentColor" strokeWidth="3" />
                </svg>
            </S.StyledCheckbox>
            <S.Label>{label}</S.Label>
        </S.Container>
    );
};

export default Checkbox;
export type { CheckboxProps } from './types';
