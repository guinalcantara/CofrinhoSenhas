import api from "../services/api";
import { fetchApi } from "../services/fetchApi";
import type { CategoriaDTO, CriarCategoriaDTO, AtualizarCategoriaDTO } from "../domain/categoria";

export const categoriaService = {
  async getAll(): Promise<CategoriaDTO[] | null> {
    return await fetchApi(() => api.get<CategoriaDTO[]>("/categorias").then(res => res.data));
  },

  async getByUsuario(idUsuario: number): Promise<CategoriaDTO[] | null> {
    return await fetchApi(() => api.get<CategoriaDTO[]>(`/categorias/usuario/${idUsuario}`).then(res => res.data));
  },

  async getById(id: number): Promise<CategoriaDTO | null> {
    return await fetchApi(() => api.get<CategoriaDTO>(`/categorias/${id}`).then(res => res.data));
  },

  async create(data: CriarCategoriaDTO): Promise<CategoriaDTO | null> {
    return await fetchApi(() => api.post<CategoriaDTO>("/categorias", data).then(res => res.data));
  },

  async update(id: number, data: AtualizarCategoriaDTO): Promise<CategoriaDTO | null> {
    return await fetchApi(() => api.put<CategoriaDTO>(`/categorias/${id}`, data).then(res => res.data));
  },

  async remove(id: number): Promise<void | null> {
    return await fetchApi(() => api.delete(`/categorias/${id}`).then(() => undefined));
  },
};
