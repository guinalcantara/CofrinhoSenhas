export interface SenhaDTO {
  id: number;
  titulo: string;
  url: string;
  login: string;
  descricao?: string;
  idUsuario: number;
  nomeUsuario?: string;
  idCategoria?: number;
  nomeCategoria?: string;
  etiquetas: string[];
  dataInclusao: string;
  dataAlteracao: string;
}

export interface CriarSenhaDTO {
  titulo: string;
  url: string;
  login: string;
  senha: string;
  descricao?: string;
  idUsuario: number;
  idCategoria?: number;
  idEtiquetas: number[];
}

export interface AtualizarSenhaDTO {
  titulo: string;
  url: string;
  login: string;
  senha?: string;
  descricao?: string;
  idCategoria?: number;
  idEtiquetas: number[];
}

export interface SenhaDescriptografadaDTO {
  id: number;
  titulo: string;
  url: string;
  login: string;
  senha: string;
  descricao?: string;
  idUsuario: number;
  idCategoria?: number;
  nomeCategoria?: string;
  etiquetas: string[];
}
