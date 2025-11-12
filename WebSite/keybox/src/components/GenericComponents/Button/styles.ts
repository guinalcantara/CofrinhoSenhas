import styled, { css } from 'styled-components';

export const StyledButton = styled.button<{ $variant: 'ok' | 'cancelar' | 'excluir' }>`
  padding: 0.75rem 1.5rem;
  border: none;
  border-radius: 8px;
  font-size: 1rem;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.3s ease;
  box-shadow: 0 2px 4px ${({ theme }) => theme.shadow};
  color: white;
  
  ${({ $variant, theme }) => {
    switch ($variant) {
      case 'ok':
        return css`
          background-color: ${theme.primary};
          &:hover:not(:disabled) {
            background-color: ${theme.primaryHover};
            transform: translateY(-2px);
            box-shadow: 0 4px 8px ${theme.shadow};
          }
        `;
      case 'cancelar':
        return css`
          background-color: ${theme.warning};
          &:hover:not(:disabled) {
            background-color: ${theme.warningLight};
            transform: translateY(-2px);
            box-shadow: 0 4px 8px ${theme.shadow};
          }
        `;
      case 'excluir':
        return css`
          background-color: ${theme.danger};
          &:hover:not(:disabled) {
            background-color: ${theme.dangerLight};
            transform: translateY(-2px);
            box-shadow: 0 4px 8px ${theme.shadow};
          }
        `;
    }
  }}

  &:active:not(:disabled) {
    transform: translateY(0);
    box-shadow: 0 1px 2px ${({ theme }) => theme.shadow};
  }

  &:disabled {
    opacity: 0.5;
    cursor: not-allowed;
  }

  &:focus {
    outline: none;
    box-shadow: 0 0 0 3px ${({ theme }) => theme.primaryLight};
  }
`;
