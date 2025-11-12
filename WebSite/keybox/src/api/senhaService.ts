import api from "../services/api";
import { fetchApi } from "../services/fetchApi";
import type { SenhaDTO, CriarSenhaDTO, AtualizarSenhaDTO, SenhaDescriptografadaDTO } from "../domain/senha";

export const senhaService = {
  async getAll(): Promise<SenhaDTO[] | null> {
    return await fetchApi(() => api.get<SenhaDTO[]>("/senhas").then(res => res.data));
  },

  async getByUsuario(idUsuario: number): Promise<SenhaDTO[] | null> {
    return await fetchApi(() => api.get<SenhaDTO[]>(`/senhas/usuario/${idUsuario}`).then(res => res.data));
  },

  async getByCategoria(idCategoria: number): Promise<SenhaDTO[] | null> {
    return await fetchApi(() => api.get<SenhaDTO[]>(`/senhas/categoria/${idCategoria}`).then(res => res.data));
  },

  async getById(id: number): Promise<SenhaDTO | null> {
    return await fetchApi(() => api.get<SenhaDTO>(`/senhas/${id}`).then(res => res.data));
  },

  async getDescriptografada(id: number): Promise<SenhaDescriptografadaDTO | null> {
    return await fetchApi(() => api.get<SenhaDescriptografadaDTO>(`/senhas/${id}/descriptografada`).then(res => res.data));
  },

  async create(data: CriarSenhaDTO): Promise<SenhaDTO | null> {
    return await fetchApi(() => api.post<SenhaDTO>("/senhas", data).then(res => res.data));
  },

  async update(id: number, data: AtualizarSenhaDTO): Promise<SenhaDTO | null> {
    return await fetchApi(() => api.put<SenhaDTO>(`/senhas/${id}`, data).then(res => res.data));
  },

  async remove(id: number): Promise<void | null> {
    return await fetchApi(() => api.delete(`/senhas/${id}`).then(() => undefined));
  },
};
