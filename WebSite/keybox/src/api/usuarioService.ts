import api from "../services/api";
import { fetchApi } from "../services/fetchApi";
import { authService } from "../services/authService";
import type { UsuarioDTO, CriarUsuarioDTO, AtualizarUsuarioDTO, LoginDTO, AlterarSenhaDTO, LoginResponse } from "../domain/usuario";

export const usuarioService = {
  async getAll(): Promise<UsuarioDTO[] | null> {
    return await fetchApi(() => api.get<UsuarioDTO[]>("/usuarios").then(res => res.data));
  },

  async getById(id: number): Promise<UsuarioDTO | null> {
    return await fetchApi(() => api.get<UsuarioDTO>(`/usuarios/${id}`).then(res => res.data));
  },

  async getByEmail(email: string): Promise<UsuarioDTO | null> {
    return await fetchApi(() => api.get<UsuarioDTO>(`/usuarios/email/${email}`).then(res => res.data));
  },

  async create(data: CriarUsuarioDTO): Promise<UsuarioDTO | null> {
    return await fetchApi(() => api.post<UsuarioDTO>("/usuarios", data).then(res => res.data));
  },

  async update(id: number, data: AtualizarUsuarioDTO): Promise<UsuarioDTO | null> {
    return await fetchApi(() => api.put<UsuarioDTO>(`/usuarios/${id}`, data).then(res => res.data));
  },

  async remove(id: number): Promise<void | null> {
    return await fetchApi(() => api.delete(`/usuarios/${id}`).then(() => undefined));
  },

  async login(data: LoginDTO): Promise<LoginResponse | null> {
    const response = await fetchApi(() => api.post<LoginResponse>("/Usuarios/login", data).then(res => res.data));
    if (response) {
      authService.setAuth(response);
    }
    return response;
  },

  async changePassword(id: number, data: AlterarSenhaDTO): Promise<string | null> {
    return await fetchApi(() => api.post<string>(`/usuarios/${id}/alterar-senha`, data).then(res => res.data));
  },
};
