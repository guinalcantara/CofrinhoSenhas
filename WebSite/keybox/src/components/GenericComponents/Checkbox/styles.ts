import styled from 'styled-components';

export const Container = styled.label`
  display: flex;
  align-items: center;
  gap: 0.75rem;
  cursor: pointer;
  user-select: none;
  transition: all 0.3s ease;

  &:hover {
    opacity: 0.8;
  }
`;

export const HiddenCheckbox = styled.input.attrs({ type: 'checkbox' })`
  position: absolute;
  opacity: 0;
  cursor: pointer;
  height: 0;
  width: 0;
`;

export const StyledCheckbox = styled.div<{ $checked: boolean; $disabled: boolean }>`
  width: 20px;
  height: 20px;
  border: 2px solid ${({ theme, $checked }) => 
    $checked ? theme.primary : theme.border};
  border-radius: 4px;
  background-color: ${({ theme, $checked }) => 
    $checked ? theme.primary : theme.surface};
  display: flex;
  align-items: center;
  justify-content: center;
  transition: all 0.3s ease;
  opacity: ${({ $disabled }) => ($disabled ? 0.5 : 1)};
  cursor: ${({ $disabled }) => ($disabled ? 'not-allowed' : 'pointer')};

  &:hover {
    border-color: ${({ theme }) => theme.primaryHover};
  }

  svg {
    width: 14px;
    height: 14px;
    fill: white;
    opacity: ${({ $checked }) => ($checked ? 1 : 0)};
    transition: opacity 0.2s ease;
  }
`;

export const Label = styled.span`
  font-size: 1rem;
  color: ${({ theme }) => theme.textPrimary};
  transition: color 0.3s ease;
`;
