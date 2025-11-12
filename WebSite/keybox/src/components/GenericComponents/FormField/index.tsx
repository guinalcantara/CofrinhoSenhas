import type { FormFieldProps } from "./types";
import * as S from "./styles";

const FormField = ({
    label,
    required = false,
    children,
    error,
    customStyle
}: FormFieldProps) => {
    return (
        <S.Container style={customStyle}>
            {label && (
                <S.Label>
                    {label}
                    {required && <S.Required>*</S.Required>}
                </S.Label>
            )}
            {children}
            {error && <S.ErrorMessage>{error}</S.ErrorMessage>}
        </S.Container>
    );
};

export default FormField;
export type { FormFieldProps } from './types';
