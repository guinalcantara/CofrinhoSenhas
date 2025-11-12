import styled from 'styled-components';

export const Nav = styled.nav`
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 1rem 2rem;
  background-color: ${({ theme }) => theme.surface};
  border-bottom: 1px solid ${({ theme }) => theme.border};
  box-shadow: 0 2px 4px ${({ theme }) => theme.shadow};
  position: sticky;
  top: 0;
  z-index: 100;
  transition: all 0.3s ease;
`;

export const NavLinks = styled.div`
  display: flex;
  gap: 1.5rem;
  align-items: center;
`;

export const NavLink = styled.a<{ $isActive: boolean }>`
  color: ${({ $isActive, theme }) => 
    $isActive ? theme.primary : theme.textSecondary};
  text-decoration: none;
  font-weight: ${({ $isActive }) => ($isActive ? '600' : '400')};
  padding: 0.5rem 1rem;
  border-radius: 6px;
  transition: all 0.2s ease;
  cursor: pointer;

  &:hover {
    color: ${({ theme }) => theme.primary};
    background-color: ${({ theme }) => theme.surfaceHover};
  }
`;

export const ThemeToggleButton = styled.button`
  background: ${({ theme }) => theme.surface};
  border: 1px solid ${({ theme }) => theme.border};
  border-radius: 50%;
  width: 40px;
  height: 40px;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  font-size: 1.2rem;
  transition: all 0.3s ease;
  color: ${({ theme }) => theme.textPrimary};

  &:hover {
    background-color: ${({ theme }) => theme.surfaceHover};
    transform: rotate(180deg);
    box-shadow: 0 2px 8px ${({ theme }) => theme.shadow};
  }

  &:active {
    transform: rotate(180deg) scale(0.95);
  }
`;

export const Logo = styled.div`
  font-size: 1.5rem;
  font-weight: 700;
  color: ${({ theme }) => theme.primary};
  display: flex;
  align-items: center;
  gap: 0.5rem;
`;
