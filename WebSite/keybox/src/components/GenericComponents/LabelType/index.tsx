import type { LabelTypeProps } from "./types";
import * as S from "./styles";

const LabelType = ({ color = "#333", values }: LabelTypeProps) => (
    <S.Container style={{ backgroundColor: color }}>
        {values.map((value, idx) => (
            <S.Item key={idx}>
                {value}
                {idx < values.length - 1 && <S.Separator> - </S.Separator>}
            </S.Item>
        ))}
    </S.Container>
);

export default LabelType;
export type { LabelTypeProps } from './types';
