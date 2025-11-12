import { showNotify } from "../utils/showNotify";
import { authService } from "./authService";

export async function fetchApi<T>(request: () => Promise<T>, customErrorMsg?: string): Promise<T | null> {
  try {
    return await request();
  } catch (error: any) {
    if (error?.response?.status === 401) {
      authService.clearAuth();
      window.location.href = "/";
      return null;
    }
    
    const msg = customErrorMsg || error?.response?.data || "Erro inesperado.";
    showNotify.error(msg);
    return null;
  }
}