import type { CardProps } from "./types";
import * as S from "./styles";

const Card = ({
  title,
  children,
  customStyle,
  onClick,
}: CardProps) => {
  return (
    <S.StyledCard
      $clickable={!!onClick}
      style={customStyle}
      onClick={onClick}
    >
      {title && <S.CardTitle>{title}</S.CardTitle>}
      {children && <S.CardContent>{children}</S.CardContent>}
    </S.StyledCard>
  );
};

export default Card;
export type { CardProps } from './types';
