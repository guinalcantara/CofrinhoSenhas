export interface EtiquetaDTO {
  id: number;
  nome: string;
  descricao: string;
  idUsuario: number;
  nomeUsuario?: string;
  dataInclusao: string;
  dataAlteracao: string;
}

export interface CriarEtiquetaDTO {
  nome: string;
  descricao: string;
  idUsuario: number;
}

export interface AtualizarEtiquetaDTO {
  nome: string;
  descricao: string;
}
