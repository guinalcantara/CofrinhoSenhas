import styled from 'styled-components';

export const Container = styled.div`
  position: relative;
  width: 100%;
`;

export const SelectButton = styled.button<{ $isOpen: boolean; $hasValue: boolean }>`
  width: 100%;
  padding: 0.75rem 1rem;
  font-size: 1rem;
  border: 2px solid ${({ theme, $isOpen }) => 
    $isOpen ? theme.primary : theme.border};
  border-radius: 8px;
  background-color: ${({ theme }) => theme.surface};
  color: ${({ theme, $hasValue }) => 
    $hasValue ? theme.textPrimary : theme.textTertiary};
  cursor: pointer;
  transition: all 0.3s ease;
  outline: none;
  display: flex;
  align-items: center;
  justify-content: space-between;
  text-align: left;
  gap: 0.5rem;

  &:hover:not(:disabled) {
    border-color: ${({ theme }) => theme.primary};
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
`;

export const SelectText = styled.span`
  flex: 1;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
`;

export const Arrow = styled.span<{ $isOpen: boolean }>`
  display: flex;
  align-items: center;
  justify-content: center;
  transition: transform 0.3s ease;
  transform: ${({ $isOpen }) => ($isOpen ? 'rotate(180deg)' : 'rotate(0)')};
  color: ${({ theme }) => theme.textSecondary};
`;

export const Dropdown = styled.div<{ $isOpen: boolean }>`
  position: absolute;
  top: calc(100% + 0.5rem);
  left: 0;
  right: 0;
  background-color: ${({ theme }) => theme.surface};
  border: 2px solid ${({ theme }) => theme.border};
  border-radius: 8px;
  box-shadow: 0 4px 12px ${({ theme }) => theme.shadow};
  max-height: 300px;
  overflow-y: auto;
  z-index: 1000;
  opacity: ${({ $isOpen }) => ($isOpen ? 1 : 0)};
  visibility: ${({ $isOpen }) => ($isOpen ? 'visible' : 'hidden')};
  transform: ${({ $isOpen }) => ($isOpen ? 'translateY(0)' : 'translateY(-10px)')};
  transition: all 0.3s ease;

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
`;

export const OptionItem = styled.div<{ $isHovered: boolean }>`
  padding: 0.5rem 0.75rem;
  cursor: pointer;
  transition: all 0.2s ease;
  background-color: ${({ theme, $isHovered }) => 
    $isHovered ? theme.surfaceHover : 'transparent'};
  user-select: none;

  &:hover {
    background-color: ${({ theme }) => theme.surfaceHover};
  }

  &:active {
    background-color: ${({ theme }) => theme.primaryLight};
  }

  &:first-child {
    border-radius: 6px 6px 0 0;
  }

  &:last-child {
    border-radius: 0 0 6px 6px;
  }

  /* Faz toda a área clicável */
  & label {
    width: 100%;
    cursor: pointer;
    pointer-events: none; /* Evita conflito de eventos */
  }
`;

export const SelectedCount = styled.span`
  background-color: ${({ theme }) => theme.primary};
  color: white;
  padding: 0.25rem 0.5rem;
  border-radius: 12px;
  font-size: 0.75rem;
  font-weight: 600;
  min-width: 20px;
  text-align: center;
`;

export const ClearButton = styled.button`
  background: none;
  border: none;
  color: ${({ theme }) => theme.textSecondary};
  cursor: pointer;
  padding: 0.25rem;
  display: flex;
  align-items: center;
  justify-content: center;
  transition: color 0.3s ease;

  &:hover {
    color: ${({ theme }) => theme.danger};
  }
`;

export const SearchInput = styled.input`
  width: 100%;
  padding: 0.75rem 1rem;
  font-size: 0.875rem;
  border: none;
  border-bottom: 1px solid ${({ theme }) => theme.border};
  background-color: ${({ theme }) => theme.surface};
  color: ${({ theme }) => theme.textPrimary};
  outline: none;
  transition: all 0.3s ease;

  &::placeholder {
    color: ${({ theme }) => theme.textTertiary};
  }

  &:focus {
    border-bottom-color: ${({ theme }) => theme.primary};
  }
`;

export const NoOptions = styled.div`
  padding: 1rem;
  text-align: center;
  color: ${({ theme }) => theme.textSecondary};
  font-size: 0.875rem;
`;
