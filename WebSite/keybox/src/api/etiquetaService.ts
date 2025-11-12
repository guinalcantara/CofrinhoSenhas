import api from "../services/api";
import { fetchApi } from "../services/fetchApi";
import type { EtiquetaDTO, CriarEtiquetaDTO, AtualizarEtiquetaDTO } from "../domain/etiqueta";

export const etiquetaService = {
  async getAll(): Promise<EtiquetaDTO[] | null> {
    return await fetchApi(() => api.get<EtiquetaDTO[]>("/etiquetas").then(res => res.data));
  },

  async getByUsuario(idUsuario: number): Promise<EtiquetaDTO[] | null> {
    return await fetchApi(() => api.get<EtiquetaDTO[]>(`/etiquetas/usuario/${idUsuario}`).then(res => res.data));
  },

  async getById(id: number): Promise<EtiquetaDTO | null> {
    return await fetchApi(() => api.get<EtiquetaDTO>(`/etiquetas/${id}`).then(res => res.data));
  },

  async create(data: CriarEtiquetaDTO): Promise<EtiquetaDTO | null> {
    return await fetchApi(() => api.post<EtiquetaDTO>("/etiquetas", data).then(res => res.data));
  },

  async update(id: number, data: AtualizarEtiquetaDTO): Promise<EtiquetaDTO | null> {
    return await fetchApi(() => api.put<EtiquetaDTO>(`/etiquetas/${id}`, data).then(res => res.data));
  },

  async remove(id: number): Promise<void | null> {
    return await fetchApi(() => api.delete(`/etiquetas/${id}`).then(() => undefined));
  },
};
