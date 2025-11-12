import type { ListProps } from "./types";
import * as S from "./styles";

const List = ({ children, style }: ListProps) => {
    return (
        <S.StyledList style={style}>
            {children}
        </S.StyledList>
    );
};

export default List;
export type { ListProps } from './types';
