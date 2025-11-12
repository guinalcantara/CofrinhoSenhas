import styled from 'styled-components';

export const Container = styled.div`
  display: flex;
  flex-direction: column;
  gap: 2rem;
  max-width: 1000px;
  margin: 0 auto;
`;

export const Section = styled.div`
  background-color: ${({ theme }) => theme.surface};
  border-radius: 12px;
  padding: 1.5rem;
  box-shadow: 0 2px 8px ${({ theme }) => theme.shadow};
  transition: all 0.3s ease;
  animation: slideUp 0.5s ease-out;

  &:hover {
    box-shadow: 0 4px 12px ${({ theme }) => theme.shadow};
  }
`;

export const SectionTitle = styled.h3`
  font-size: 1.25rem;
  font-weight: 600;
  color: ${({ theme }) => theme.textPrimary};
  margin-bottom: 1.5rem;
  padding-bottom: 0.75rem;
  border-bottom: 2px solid ${({ theme }) => theme.primary};
`;

export const PasswordBox = styled.div`
  display: flex;
  align-items: center;
  gap: 1rem;
  padding: 1.25rem;
`;

export const Password = styled.span`
  flex: 1;
  font-size: 1.25rem;
  color: ${({ theme }) => theme.textPrimary};
  word-break: break-all;
  min-height: 1.5rem;
  display: flex;
  align-items: center;
`;

export const CopyButton = styled.button`
  padding: 0.75rem 1.5rem;
  background-color: white;
  color: ${({ theme }) => theme.primary};
  border: none;
  border-radius: 6px;
  font-size: 1rem;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.3s ease;
  white-space: nowrap;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);

  &:hover:not(:disabled) {
    transform: scale(1.05);
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
  }

  &:active:not(:disabled) {
    transform: scale(0.98);
  }

  &:disabled {
    opacity: 0.5;
    cursor: not-allowed;
  }
`;

export const Options = styled.div`
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
  gap: 1rem;
  margin-bottom: 1.5rem;
`;

export const LengthControl = styled.div`
  display: flex;
  flex-direction: column;
  gap: 1rem;
  padding: 1rem;
  background-color: ${({ theme }) => theme.backgroundAlt};
  border-radius: 8px;
  border: 1px solid ${({ theme }) => theme.border};
`;

export const LengthLabel = styled.div`
  display: flex;
  justify-content: space-between;
  align-items: center;
  
  span:first-child {
    font-weight: 500;
    color: ${({ theme }) => theme.textPrimary};
  }
`;

export const LengthValue = styled.span`
  font-weight: 700;
  color: ${({ theme }) => theme.primary};
  font-size: 1.125rem;
`;

export const RangeInput = styled.input`
  width: 100%;
  height: 8px;
  border-radius: 4px;
  background: ${({ theme }) => theme.border};
  outline: none;
  -webkit-appearance: none;
  appearance: none;
  transition: all 0.3s ease;

  &::-webkit-slider-thumb {
    -webkit-appearance: none;
    appearance: none;
    width: 20px;
    height: 20px;
    border-radius: 50%;
    background: ${({ theme }) => theme.primary};
    cursor: pointer;
    transition: all 0.3s ease;
    box-shadow: 0 2px 4px ${({ theme }) => theme.shadow};

    &:hover {
      transform: scale(1.2);
      background: ${({ theme }) => theme.primaryHover};
    }
  }

  &::-moz-range-thumb {
    width: 20px;
    height: 20px;
    border-radius: 50%;
    background: ${({ theme }) => theme.primary};
    cursor: pointer;
    border: none;
    transition: all 0.3s ease;
    box-shadow: 0 2px 4px ${({ theme }) => theme.shadow};

    &:hover {
      transform: scale(1.2);
      background: ${({ theme }) => theme.primaryHover};
    }
  }

  &::-webkit-slider-runnable-track {
    width: 100%;
    height: 8px;
    border-radius: 4px;
    background: linear-gradient(
      to right,
      ${({ theme }) => theme.primary} 0%,
      ${({ theme }) => theme.primary} ${props => ((props.value as number - 6) / (32 - 6)) * 100}%,
      ${({ theme }) => theme.border} ${props => ((props.value as number - 6) / (32 - 6)) * 100}%,
      ${({ theme }) => theme.border} 100%
    );
  }

  &::-moz-range-track {
    width: 100%;
    height: 8px;
    border-radius: 4px;
    background: ${({ theme }) => theme.border};
  }
`;

export const Actions = styled.div`
  display: flex;
  gap: 1rem;
  justify-content: center;
  flex-wrap: wrap;

  button {
    min-width: 200px;
  }
`;
