import type { AccountIconProps } from "./types";
import * as S from "./styles";

const DEFAULT_ICON = "https://www.gstatic.com/images/branding/product/1x/avatar_square_blue_512dp.png";

const AccountIcon = ({ size = 40, src, alt = "Conta" }: AccountIconProps) => (
    <S.Icon
        src={src || DEFAULT_ICON}
        alt={alt}
        width={size}
        height={size}
    />
);

export default AccountIcon;
export type { AccountIconProps } from './types';
