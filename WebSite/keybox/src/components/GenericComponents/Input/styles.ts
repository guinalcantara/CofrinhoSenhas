import styled from 'styled-components';

export const Container = styled.div`
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
  width: 100%;
`;

export const Label = styled.label`
  font-size: 0.875rem;
  font-weight: 500;
  color: ${({ theme }) => theme.textPrimary};
  transition: color 0.3s ease;
`;

export const PlaceholderLabel = styled.div`
  font-size: 0.875rem;
  color: ${({ theme }) => theme.textSecondary};
  transition: color 0.3s ease;
`;

export const InputWrapper = styled.div`
  position: relative;
  display: flex;
  align-items: center;
`;

export const StyledInput = styled.input`
  width: 100%;
  padding: 0.75rem 1rem;
  font-size: 1rem;
  border: 2px solid ${({ theme }) => theme.border};
  border-radius: 8px;
  background-color: ${({ theme }) => theme.surface};
  color: ${({ theme }) => theme.textPrimary};
  transition: all 0.3s ease;
  outline: none;

  &::placeholder {
    color: ${({ theme }) => theme.textTertiary};
  }

  &:focus {
    border-color: ${({ theme }) => theme.primary};
    box-shadow: 0 0 0 3px ${({ theme }) => theme.primaryLight};
  }

  &:disabled {
    opacity: 0.6;
    cursor: not-allowed;
    background-color: ${({ theme }) => theme.borderLight};
  }

  &:hover:not(:disabled) {
    border-color: ${({ theme }) => theme.primary};
  }

  /* Autocomplete styles for Chrome/Safari/Edge */
  &:-webkit-autofill,
  &:-webkit-autofill:hover,
  &:-webkit-autofill:focus,
  &:-webkit-autofill:active {
    -webkit-box-shadow: 0 0 0 30px ${({ theme }) => theme.surface} inset !important;
    -webkit-text-fill-color: ${({ theme }) => theme.textPrimary} !important;
    caret-color: ${({ theme }) => theme.textPrimary};
    transition: background-color 5000s ease-in-out 0s;
  }

  /* Autocomplete styles for Firefox */
  &:-moz-autofill,
  &:-moz-autofill-preview {
    background-color: ${({ theme }) => theme.surface} !important;
    color: ${({ theme }) => theme.textPrimary} !important;
  }
`;

export const Icon = styled.span`
  position: absolute;
  right: 1rem;
  font-size: 1.25rem;
  cursor: pointer;
  user-select: none;
  color: ${({ theme }) => theme.textSecondary};
  transition: color 0.3s ease;

  &:hover {
    color: ${({ theme }) => theme.primary};
  }
`;

export const ErrorMessage = styled.p`
  color: ${({ theme }) => theme.danger};
  margin-top: 0.25rem;
  font-size: 0.875rem;
  animation: fadeIn 0.3s ease;
`;
