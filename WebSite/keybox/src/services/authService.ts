interface AuthResponse {
  usuario: {
    id: number;
    nome: string;
    email: string;
    dataUltimoLogin: string;
    ativo: boolean;
    dataInclusao: string;
    dataAlteracao: string;
  };
  token: string;
  dataExpiracao: string;
}

const TOKEN_KEY = '@keybox:token';
const USER_KEY = '@keybox:user';
const EXPIRATION_KEY = '@keybox:expiration';

export const authService = {
  setAuth(authData: AuthResponse): void {
    localStorage.setItem(TOKEN_KEY, authData.token);
    localStorage.setItem(USER_KEY, JSON.stringify(authData.usuario));
    localStorage.setItem(EXPIRATION_KEY, authData.dataExpiracao);
  },

  getToken(): string | null {
    return localStorage.getItem(TOKEN_KEY);
  },

  getUser(): AuthResponse['usuario'] | null {
    const user = localStorage.getItem(USER_KEY);
    return user ? JSON.parse(user) : null;
  },

  getExpiration(): string | null {
    return localStorage.getItem(EXPIRATION_KEY);
  },

  isAuthenticated(): boolean {
    const token = this.getToken();
    const expiration = this.getExpiration();
    
    if (!token || !expiration) {
      return false;
    }

    const expirationDate = new Date(expiration);
    const now = new Date();
    
    if (now >= expirationDate) {
      this.clearAuth();
      return false;
    }

    return true;
  },

  clearAuth(): void {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(USER_KEY);
    localStorage.removeItem(EXPIRATION_KEY);
  },

  logout(): void {
    this.clearAuth();
  }
};
