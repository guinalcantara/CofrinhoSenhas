import { Link } from "react-router-dom";
import type { PageContainerProps } from "./types";
import * as S from "./styles";

const PageContainer = ({ children, title, breadcrumbs, actions }: PageContainerProps) => {
    return (
        <S.Container>
            {(breadcrumbs || title) && (
                <S.PageHeader>
                    {breadcrumbs && (
                        <S.Breadcrumbs>
                            {breadcrumbs.map((breadcrumb, index) => (
                                <S.BreadcrumbItem key={index}>
                                    {breadcrumb.path ? (
                                        <Link to={breadcrumb.path} style={{ textDecoration: 'none' }}>
                                            <S.BreadcrumbLink>
                                                {breadcrumb.title}
                                            </S.BreadcrumbLink>
                                        </Link>
                                    ) : (
                                        <S.BreadcrumbCurrent>{breadcrumb.title}</S.BreadcrumbCurrent>
                                    )}
                                    {index < breadcrumbs.length - 1 && (
                                        <S.BreadcrumbSeparator>/</S.BreadcrumbSeparator>
                                    )}
                                </S.BreadcrumbItem>
                            ))}
                        </S.Breadcrumbs>
                    )}
                    <S.TitleRow>
                        {title && <S.PageTitle>{title}</S.PageTitle>}
                        {actions && <S.PageActions>{actions}</S.PageActions>}
                    </S.TitleRow>
                </S.PageHeader>
            )}
            <S.PageContent>{children}</S.PageContent>
        </S.Container>
    );
};

export default PageContainer;
export type { PageContainerProps, Breadcrumb } from './types';
