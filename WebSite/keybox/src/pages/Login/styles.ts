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

export const Logo = styled.div`
  font-size: 4rem;
  text-align: center;
  margin-bottom: 1rem;
  animation: pulse 2s ease-in-out infinite;
`;

export const Title = styled.h1`
  font-size: 2rem;
  text-align: center;
  margin-bottom: 0.5rem;
  color: ${({ theme }) => theme.textPrimary};
`;

export const Subtitle = styled.p`
  text-align: center;
  color: ${({ theme }) => theme.textSecondary};
  margin-bottom: 2rem;
`;

export const Form = styled.form`
  display: flex;
  flex-direction: column;
  gap: 1.5rem;
`;

export const RegisterLink = styled.p`
  text-align: center;
  margin-top: 1.5rem;
  color: ${({ theme }) => theme.textSecondary};

  a {
    color: ${({ theme }) => theme.primary};
    text-decoration: none;
    font-weight: 600;
    transition: color 0.3s ease;

    &:hover {
      color: ${({ theme }) => theme.primaryHover};
      text-decoration: underline;
    }
  }
`;

export const FeaturesGrid = styled.div`
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 1rem;
  margin-top: 2rem;
  padding-top: 2rem;
  border-top: 1px solid ${({ theme }) => theme.border};
`;

export const Feature = styled.div`
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

export const FeatureIcon = styled.div`
  font-size: 2rem;
  margin-bottom: 0.5rem;
`;

export const FeatureText = styled.p`
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
