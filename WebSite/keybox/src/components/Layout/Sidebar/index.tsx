import { NavLink, useLocation, useNavigate } from "react-router-dom";
import { useState } from "react";
import { authService } from "../../../services/authService";
import type { MenuItem } from "./types";
import * as S from "./styles";

const menuItems: MenuItem[] = [
    { id: "home", title: "Home", icon: "🏠", path: "/home" },
    { id: "passwords", title: "Nova Senha", icon: "🔑", path: "/criar-senha" },
];

const Sidebar = () => {
    const [isOpen, setIsOpen] = useState(true);
    const location = useLocation();
    const navigate = useNavigate();
    const user = authService.getUser();

    const handleLogout = () => {
        authService.logout();
        navigate("/");
    };

    return (
        <S.Aside $isOpen={isOpen}>
            <S.SidebarHeader>
                <S.ToggleButton
                    onClick={() => setIsOpen(!isOpen)}
                    aria-label="Toggle sidebar"
                >
                    <S.Hamburger />
                    <S.Hamburger />
                    <S.Hamburger />
                </S.ToggleButton>
                <S.MenuLabel $isOpen={isOpen}>Menu</S.MenuLabel>
            </S.SidebarHeader>
            <S.SidebarContent>
                <S.Nav>
                    {menuItems.map((item) => (
                        <NavLink
                            key={item.id}
                            to={item.path}
                            style={{ textDecoration: 'none' }}
                        >
                            <S.NavItem $isActive={location.pathname === item.path}>
                                <S.NavIcon>{item.icon}</S.NavIcon>
                                <S.NavText $isOpen={isOpen}>{item.title}</S.NavText>
                            </S.NavItem>
                        </NavLink>
                    ))}
                </S.Nav>
                <S.UserSection>
                    <S.UserInfo onClick={handleLogout}>
                        <S.UserAvatar>
                            {user?.nome?.charAt(0).toUpperCase() || ""}
                        </S.UserAvatar>
                        <S.UserName $isOpen={isOpen}>{(user?.nome ? `${user.nome} - Sair` : "Sair")}</S.UserName>
                    </S.UserInfo>
                </S.UserSection>
            </S.SidebarContent>
        </S.Aside>
    );
};

export default Sidebar;
export type { MenuItem } from './types';
