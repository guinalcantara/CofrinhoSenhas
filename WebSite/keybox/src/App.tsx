import { Routes, Route, useLocation, Navigate } from "react-router-dom";
import Login from "./pages/Login";
import Home from "./pages/Home";
import EditPassword from "./pages/EditPassword";
import Register from "./pages/Register";
import CreatePassword from "./pages/CreatePassword";
import { DashboardLayout } from "./components/Layout";
import ProtectedRoute from "./components/ProtectedRoute";

const App: React.FC = () => {
  const location = useLocation();
  const isLoginPage = location.pathname === "/login";
  const isRegisterPage = location.pathname === "/registrar";

  // Páginas públicas sem dashboard layout
  if (isLoginPage || isRegisterPage) {
    return (
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/registrar" element={<Register />} />
      </Routes>
    );
  }

  // Páginas com dashboard layout
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/login" replace />} />
      <Route element={
        <ProtectedRoute>
          <DashboardLayout />
        </ProtectedRoute>
      }>
        <Route path="/home" element={<Home />} />
        <Route path="/editar/:id" element={<EditPassword />} />
        <Route path="/editar" element={<EditPassword />} />
        <Route path="/criar-senha" element={<CreatePassword />} />
      </Route>
    </Routes>
  );
};

export default App;
