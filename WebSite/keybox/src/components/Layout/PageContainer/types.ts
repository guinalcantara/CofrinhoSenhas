import type { ReactNode } from "react";

export interface Breadcrumb {
    title: string;
    path?: string;
}

export interface PageContainerProps {
    children: ReactNode;
    title?: string;
    breadcrumbs?: Breadcrumb[];
    actions?: ReactNode;
}
