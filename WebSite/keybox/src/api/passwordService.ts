import api from "../services/api";
import { fetchApi } from "../services/fetchApi";
import type { SenhaDTO } from "../domain/senha";

export const passwordService = {
  async getAll(): Promise<SenhaDTO[] | null> {
    return await fetchApi(() => api.get<SenhaDTO[]>("/senhas").then(res => res.data));
  },

  async getById(id: number): Promise<SenhaDTO | null> {
    return await fetchApi(() => api.get<SenhaDTO>(`/senhas/${id}`).then(res => res.data));
  },

  async create(data: Omit<SenhaDTO, "id" | "dataInclusao" | "dataAlteracao">): Promise<SenhaDTO | null> {
    return await fetchApi(() => api.post<SenhaDTO>("/senhas", data).then(res => res.data));
  },

  async update(id: number, data: Partial<SenhaDTO>): Promise<SenhaDTO | null> {
    return await fetchApi(() => api.put<SenhaDTO>(`/senhas/${id}`, data).then(res => res.data));
  },

  async remove(id: number): Promise<void | null> {
    return await fetchApi(() => api.delete(`/senhas/${id}`).then(() => undefined));
  },
};
