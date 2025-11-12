import styled from 'styled-components';

export const Container = styled.div`
  padding: 2rem;
  width: 100%;
  background-color: ${({ theme }) => theme.background};
  transition: background-color 0.3s ease;
`;

export const PageHeader = styled.div`
  margin-bottom: 2rem;
  animation: slideUp 0.5s ease-out;
`;

export const Breadcrumbs = styled.nav`
  display: flex;
  align-items: center;
  gap: 0.5rem;
  margin-bottom: 1rem;
  font-size: 0.875rem;
  color: ${({ theme }) => theme.textSecondary};
`;

export const BreadcrumbItem = styled.span`
  display: flex;
  align-items: center;
  gap: 0.5rem;
`;

export const BreadcrumbLink = styled.a`
  color: ${({ theme }) => theme.primary};
  text-decoration: none;
  transition: color 0.3s ease;

  &:hover {
    color: ${({ theme }) => theme.primaryHover};
    text-decoration: underline;
  }
`;

export const BreadcrumbCurrent = styled.span`
  color: ${({ theme }) => theme.textPrimary};
  font-weight: 500;
`;

export const BreadcrumbSeparator = styled.span`
  color: ${({ theme }) => theme.textTertiary};
`;

export const TitleRow = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 1rem;
  flex-wrap: wrap;
`;

export const PageTitle = styled.h1`
  font-size: 2rem;
  font-weight: 700;
  color: ${({ theme }) => theme.textPrimary};
  margin: 0;
  transition: color 0.3s ease;
`;

export const PageActions = styled.div`
  display: flex;
  align-items: center;
  gap: 0.75rem;
`;

export const PageContent = styled.div`
  animation: fadeIn 0.5s ease-out;
`;
