import { Link, useLocation } from "react-router-dom";
import type { NavItem } from "./types";
import { useTheme } from "../../../contexts/ThemeContext";
import * as S from "./styles";

const navItems: NavItem[] = [
    { label: "Login", path: "/login" },
    { label: "Home", path: "/home" },
    { label: "Editar", path: "/editar" },
    { label: "Cadastrar Usuário", path: "/registrar" },
];

const NavBar = () => {
    const location = useLocation();
    const { themeMode, toggleTheme } = useTheme();

    return (
        <S.Nav>
            <S.Logo>
                🔐 KeyBox
            </S.Logo>
            <S.NavLinks>
                {navItems.map((item) => (
                    <Link
                        key={item.path}
                        to={item.path}
                        style={{ textDecoration: 'none' }}
                    >
                        <S.NavLink $isActive={location.pathname === item.path}>
                            {item.label}
                        </S.NavLink>
                    </Link>
                ))}
                <S.ThemeToggleButton
                    onClick={toggleTheme}
                    aria-label="Toggle theme"
                    title={`Switch to ${themeMode === 'light' ? 'dark' : 'light'} mode`}
                >
                    {themeMode === 'light' ? '🌙' : '☀️'}
                </S.ThemeToggleButton>
            </S.NavLinks>
        </S.Nav>
    );
};

export default NavBar;
export type { NavItem } from './types';
