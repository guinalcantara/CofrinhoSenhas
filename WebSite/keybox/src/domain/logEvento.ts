export interface LogEventoDTO {
  id: number;
  evento: string;
  descricao: string;
  enderecoIP?: string;
  idUsuario?: number;
  nomeUsuario?: string;
  dataInclusao: string;
  dataAlteracao: string;
}

export interface CriarLogEventoDTO {
  evento: string;
  descricao: string;
  enderecoIP?: string;
  idUsuario?: number;
}
