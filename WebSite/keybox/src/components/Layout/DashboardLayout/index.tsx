import { Outlet } from "react-router-dom";
import Sidebar from "../Sidebar";
import Header from "../Header";
import * as S from "./styles";

const DashboardLayout = () => {
    return (
        <S.DashboardContainer>
            <Header />
            <S.DashboardContent>
                <Sidebar />
                <S.MainContent>
                    <Outlet />
                </S.MainContent>
            </S.DashboardContent>
        </S.DashboardContainer>
    );
};

export default DashboardLayout;
