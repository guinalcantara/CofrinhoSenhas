import { useTheme } from "../../../contexts/ThemeContext";
import * as S from "./styles";

const Header = () => {
    const { themeMode, toggleTheme } = useTheme();

    return (
        <S.StyledHeader>
            <S.HeaderContent>
                <S.Logo>
                    <S.LogoIcon>🔐</S.LogoIcon>
                    <S.LogoText>KeyBox</S.LogoText>
                </S.Logo>
                <S.ThemeToggle
                    onClick={toggleTheme}
                    aria-label="Toggle theme"
                    title={`Mudar para modo ${themeMode === 'light' ? 'escuro' : 'claro'}`}
                >
                    {themeMode === 'light' ? '🌙' : '☀️'}
                </S.ThemeToggle>
            </S.HeaderContent>
        </S.StyledHeader>
    );
};

export default Header;
