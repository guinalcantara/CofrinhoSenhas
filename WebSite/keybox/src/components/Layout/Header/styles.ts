import styled from 'styled-components';

export const StyledHeader = styled.header`
  background-color: ${({ theme }) => theme.surface};
  border-bottom: 1px solid ${({ theme }) => theme.border};
  box-shadow: 0 2px 4px ${({ theme }) => theme.shadow};
  position: sticky;
  top: 0;
  z-index: 100;
  transition: all 0.3s ease;
`;

export const HeaderContent = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 1rem 2rem;
  max-width: 100%;
`;

export const Logo = styled.div`
  display: flex;
  align-items: center;
  gap: 0.75rem;
`;

export const LogoIcon = styled.span`
  font-size: 2rem;
`;

export const LogoText = styled.h1`
  font-size: 1.5rem;
  font-weight: 700;
  color: ${({ theme }) => theme.primary};
  margin: 0;
`;

export const ThemeToggle = styled.button`
  background: ${({ theme }) => theme.surface};
  border: 2px solid ${({ theme }) => theme.border};
  border-radius: 50%;
  width: 44px;
  height: 44px;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  font-size: 1.25rem;
  transition: all 0.3s ease;
  color: ${({ theme }) => theme.textPrimary};

  &:hover {
    background-color: ${({ theme }) => theme.surfaceHover};
    transform: rotate(180deg);
    box-shadow: 0 2px 8px ${({ theme }) => theme.shadow};
    border-color: ${({ theme }) => theme.primary};
  }

  &:active {
    transform: rotate(180deg) scale(0.95);
  }
`;
