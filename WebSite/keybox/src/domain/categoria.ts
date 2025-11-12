export interface CategoriaDTO {
  id: number;
  nome: string;
  descricao?: string;
  idUsuario?: number;
  nomeUsuario?: string;
  dataInclusao: string;
  dataAlteracao: string;
}

export interface CriarCategoriaDTO {
  nome: string;
  descricao?: string;
  idUsuario?: number;
}

export interface AtualizarCategoriaDTO {
  nome: string;
  descricao?: string;
}
