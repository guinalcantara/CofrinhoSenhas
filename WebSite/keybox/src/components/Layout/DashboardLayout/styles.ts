import styled from 'styled-components';

export const DashboardContainer = styled.div`
  display: flex;
  flex-direction: column;
  background-color: ${({ theme }) => theme.background};
  transition: background-color 0.3s ease;
`;

export const DashboardContent = styled.div`
  display: flex;
  flex: 1;
  overflow: hidden;
`;

export const MainContent = styled.main`
  flex: 1;
  overflow-y: auto;
  background-color: ${({ theme }) => theme.background};
  transition: background-color 0.3s ease;

  /* Custom scrollbar */
  &::-webkit-scrollbar {
    width: 6px;
  }

  &::-webkit-scrollbar-track {
    background: transparent;
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
