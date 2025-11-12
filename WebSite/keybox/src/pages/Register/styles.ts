import styled from 'styled-components';

export const Container = styled.div`
  min-height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 3rem 1rem;
  background: ${({ theme }) => theme.gradient};
  overflow-y: auto;
`;

export const Header = styled.div`
  text-align: center;
  margin-bottom: 2rem;
`;

export const Logo = styled.div`
  font-size: 3rem;
  animation: pulse 2s ease-in-out infinite;
`;

export const Title = styled.h1`
  font-size: 2rem;
  margin: 1rem 0 0.5rem;
  color: ${({ theme }) => theme.textPrimary};
`;

export const Subtitle = styled.p`
  color: ${({ theme }) => theme.textSecondary};
`;

export const Form = styled.form`
  display: flex;
  flex-direction: column;
  gap: 1.5rem;
`;

export const PasswordStrength = styled.div<{ $level: 'weak' | 'medium' | 'strong' }>`
  font-size: 0.875rem;
  font-weight: 600;
  margin-top: 0.5rem;
  color: ${({ $level, theme }) => {
    if ($level === 'weak') return theme.danger;
    if ($level === 'medium') return theme.warning;
    return theme.success;
  }};
`;

export const StrengthBar = styled.div`
  height: 4px;
  background-color: ${({ theme }) => theme.borderLight};
  border-radius: 2px;
  margin-top: 0.5rem;
  overflow: hidden;
`;

export const StrengthFill = styled.div<{ $level: 'weak' | 'medium' | 'strong' }>`
  height: 100%;
  transition: all 0.3s ease;
  border-radius: 2px;
  width: ${({ $level }) => {
    if ($level === 'weak') return '33%';
    if ($level === 'medium') return '66%';
    return '100%';
  }};
  background-color: ${({ $level, theme }) => {
    if ($level === 'weak') return theme.danger;
    if ($level === 'medium') return theme.warning;
    return theme.success;
  }};
`;

export const Requirements = styled.div`
  padding: 1rem;
  background-color: ${({ theme }) => theme.infoLight};
  border-left: 4px solid ${({ theme }) => theme.info};
  border-radius: 8px;
`;

export const RequirementTitle = styled.div`
  font-weight: 600;
  margin-bottom: 0.5rem;
  color: ${({ theme }) => theme.textPrimary};
  font-size: 0.875rem;
`;

export const RequirementList = styled.ul`
  list-style: none;
  padding-left: 0;
`;

export const RequirementItem = styled.li`
  font-size: 0.875rem;
  color: ${({ theme }) => theme.textSecondary};
  margin: 0.25rem 0;
  padding-left: 1.25rem;
  position: relative;

  &::before {
    content: "•";
    position: absolute;
    left: 0;
    color: ${({ theme }) => theme.info};
    font-weight: bold;
  }
`;

export const BackLink = styled.a`
  text-align: center;
  color: ${({ theme }) => theme.primary};
  text-decoration: none;
  font-size: 0.875rem;
  font-weight: 600;
  cursor: pointer;
  transition: color 0.3s ease;

  &:hover {
    color: ${({ theme }) => theme.primaryHover};
    text-decoration: underline;
  }
`;

export const BenefitsGrid = styled.div`
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 1rem;
  margin-top: 2rem;
  padding-top: 2rem;
  border-top: 1px solid ${({ theme }) => theme.border};
`;

export const Benefit = styled.div`
  text-align: center;
  padding: 1rem;
  border-radius: 8px;
  background-color: ${({ theme }) => theme.surfaceHover};
  transition: all 0.3s ease;

  &:hover {
    transform: translateY(-2px);
    box-shadow: 0 4px 8px ${({ theme }) => theme.shadow};
  }
`;

export const BenefitIcon = styled.div`
  font-size: 2rem;
  margin-bottom: 0.5rem;
`;

export const BenefitText = styled.p`
  font-size: 0.875rem;
  color: ${({ theme }) => theme.textSecondary};
  font-weight: 500;
`;

export const ThemeToggle = styled.button`
  position: fixed;
  top: 2rem;
  right: 2rem;
  background: ${({ theme }) => theme.surface};
  border: 2px solid ${({ theme }) => theme.border};
  border-radius: 50%;
  width: 56px;
  height: 56px;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  font-size: 1.5rem;
  transition: all 0.3s ease;
  color: ${({ theme }) => theme.textPrimary};
  box-shadow: 0 4px 12px ${({ theme }) => theme.shadow};
  z-index: 1000;

  &:hover {
    transform: rotate(180deg) scale(1.1);
    box-shadow: 0 6px 16px ${({ theme }) => theme.shadow};
    border-color: ${({ theme }) => theme.primary};
  }

  &:active {
    transform: rotate(180deg) scale(0.95);
  }
`;
