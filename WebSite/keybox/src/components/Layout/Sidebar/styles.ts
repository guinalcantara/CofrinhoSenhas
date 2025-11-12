import styled from 'styled-components';

export const Aside = styled.aside<{ $isOpen: boolean }>`
  width: ${({ $isOpen }) => ($isOpen ? '240px' : '64px')};
  background-color: ${({ theme }) => theme.surface};
  border-right: 1px solid ${({ theme }) => theme.border};
  display: flex;
  flex-direction: column;
  transition: width 0.3s ease;
  position: relative;
  height: 100vh;
  overflow: hidden;

  @media (max-width: 768px) {
    position: fixed;
    left: 0;
    top: 64px;
    height: calc(100vh - 64px);
    z-index: 50;
    transform: translateX(${({ $isOpen }) => ($isOpen ? '0' : '-100%')});
    transition: transform 0.3s ease;
    width: 240px;
  }
`;

export const SidebarHeader = styled.div`
  padding: 1rem;
  border-bottom: 1px solid ${({ theme }) => theme.border};
  display: flex;
  align-items: center;
  gap: 1rem;
  flex-shrink: 0;
`;

export const SidebarContent = styled.div`
  flex: 1;
  display: flex;
  flex-direction: column;
  min-height: 0;
  overflow: hidden;
`;

export const ToggleButton = styled.button`
  background: none;
  border: none;
  cursor: pointer;
  padding: 0.5rem;
  display: flex;
  flex-direction: column;
  gap: 4px;
  border-radius: 4px;
  transition: background-color 0.2s;
  min-width: 32px;

  &:hover {
    background-color: ${({ theme }) => theme.surfaceHover};
  }
`;

export const Hamburger = styled.span`
  width: 20px;
  height: 2px;
  background-color: ${({ theme }) => theme.textPrimary};
  transition: all 0.3s ease;
  display: block;
`;

export const MenuLabel = styled.span<{ $isOpen: boolean }>`
  font-size: 0.875rem;
  font-weight: 600;
  color: ${({ theme }) => theme.textSecondary};
  text-transform: uppercase;
  letter-spacing: 0.5px;
  transition: opacity 0.3s ease;
  opacity: ${({ $isOpen }) => ($isOpen ? 1 : 0)};
  width: ${({ $isOpen }) => ($isOpen ? 'auto' : '0')};
  overflow: hidden;
  white-space: nowrap;
`;

export const Nav = styled.nav`
  display: flex;
  flex-direction: column;
  padding: 0.5rem;
  gap: 0.25rem;
  overflow-y: auto;
  flex: 1 1 auto;
  min-height: 0;
`;

export const NavItem = styled.div<{ $isActive: boolean }>`
  display: flex;
  align-items: center;
  gap: 1rem;
  padding: 0.75rem 1rem;
  color: ${({ theme }) => theme.textPrimary};
  text-decoration: none;
  border-radius: 8px;
  transition: all 0.2s;
  white-space: nowrap;
  cursor: pointer;
  background-color: ${({ $isActive, theme }) => 
    $isActive ? theme.primaryLight : 'transparent'};
  color: ${({ $isActive, theme }) => 
    $isActive ? theme.primary : theme.textSecondary};
  font-weight: ${({ $isActive }) => ($isActive ? '600' : '400')};

  &:hover {
    background-color: ${({ theme }) => theme.surfaceHover};
  }
`;

export const NavIcon = styled.span`
  font-size: 1.5rem;
  min-width: 24px;
  display: flex;
  align-items: center;
  justify-content: center;
`;

export const NavText = styled.span<{ $isOpen: boolean }>`
  transition: opacity 0.3s ease;
  opacity: ${({ $isOpen }) => ($isOpen ? 1 : 0)};
  width: ${({ $isOpen }) => ($isOpen ? 'auto' : '0')};
  overflow: hidden;
`;

export const UserSection = styled.div`
  border-top: 1px solid ${({ theme }) => theme.border};
  padding: 1rem;
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
  flex-shrink: 0;
  flex-grow: 0;
`;

export const UserInfo = styled.div`
  display: flex;
  align-items: center;
  gap: 0.75rem;
  padding: 0.5rem;
  cursor: pointer; 
`;

export const UserAvatar = styled.div`
  width: 40px;
  height: 40px;
  min-width: 40px;
  border-radius: 50%;
  background: ${({ theme }) => theme.primary};
  color: white;
  display: flex;
  align-items: center;
  justify-content: center;
  font-weight: 600;
  font-size: 1.125rem;
`;

export const UserName = styled.span<{ $isOpen: boolean }>`
  font-weight: 500;
  color: ${({ theme }) => theme.textPrimary};
  font-size: 0.875rem;
  transition: opacity 0.3s ease;
  opacity: ${({ $isOpen }) => ($isOpen ? 1 : 0)};
  width: ${({ $isOpen }) => ($isOpen ? 'auto' : '0')};
  overflow: hidden;
  white-space: nowrap;
`;