import styled, { css } from 'styled-components';

export const StyledCard = styled.div<{ $clickable: boolean }>`
  background-color: ${({ theme }) => theme.surface};
  border-radius: 12px;
  padding: 1.5rem;
  box-shadow: 0 2px 8px ${({ theme }) => theme.shadow};
  transition: all 0.3s ease;
  animation: slideUp 0.5s ease-out;
  overflow-y: auto;
  max-height: calc(100vh - 10rem);
  margin: 2rem 0;

  /* Custom scrollbar */
  &::-webkit-scrollbar {
    width: 6px;
  }

  &::-webkit-scrollbar-track {
    background: transparent;
    border-radius: 10px;
  }

  &::-webkit-scrollbar-thumb {
    background: ${({ theme }) => theme.border};
    border-radius: 10px;
    transition: background 0.3s ease;
  }

  &::-webkit-scrollbar-thumb:hover {
    background: ${({ theme }) => theme.textTertiary};
  }

  scrollbar-width: thin;
  scrollbar-color: ${({ theme }) => theme.border} transparent;

  ${({ $clickable }) =>
    $clickable &&
    css`
      cursor: pointer;

      &:hover {
        transform: translateY(-4px);
        box-shadow: 0 4px 16px ${({ theme }) => theme.shadow};
      }
    `}
`;

export const CardTitle = styled.h2`
  font-size: 1.5rem;
  font-weight: 600;
  color: ${({ theme }) => theme.textPrimary};
  margin-bottom: 1rem;
  border-bottom: 2px solid ${({ theme }) => theme.primary};
  padding-bottom: 0.5rem;
`;

export const CardContent = styled.div`
  color: ${({ theme }) => theme.textSecondary};
`;
