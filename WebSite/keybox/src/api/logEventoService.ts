import api from "../services/api";
import { fetchApi } from "../services/fetchApi";
import type { LogEventoDTO, CriarLogEventoDTO } from "../domain/logEvento";

export const logEventoService = {
  async getAll(): Promise<LogEventoDTO[] | null> {
    return await fetchApi(() => api.get<LogEventoDTO[]>("/logeventos").then(res => res.data));
  },

  async getByUsuario(idUsuario: number): Promise<LogEventoDTO[] | null> {
    return await fetchApi(() => api.get<LogEventoDTO[]>(`/logeventos/usuario/${idUsuario}`).then(res => res.data));
  },

  async getById(id: number): Promise<LogEventoDTO | null> {
    return await fetchApi(() => api.get<LogEventoDTO>(`/logeventos/${id}`).then(res => res.data));
  },

  async create(data: CriarLogEventoDTO): Promise<LogEventoDTO | null> {
    return await fetchApi(() => api.post<LogEventoDTO>("/logeventos", data).then(res => res.data));
  },

  async remove(id: number): Promise<void | null> {
    return await fetchApi(() => api.delete(`/logeventos/${id}`).then(() => undefined));
  },
};
