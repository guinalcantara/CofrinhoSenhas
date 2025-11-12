export interface UsuarioDTO {
  id: number;
  nome: string;
  email: string;
  dataUltimoLogin?: string;
  ativo: boolean;
  dataInclusao: string;
  dataAlteracao: string;
}

export interface CriarUsuarioDTO {
  nome: string;
  email: string;
  senha: string;
}

export interface AtualizarUsuarioDTO {
  nome: string;
  email: string;
}

export interface LoginDTO {
  email: string;
  senha: string;
}

export interface AlterarSenhaDTO {
  senhaAtual: string;
  novaSenha: string;
}

export interface LoginResponse {
  usuario: {
    id: number;
    nome: string;
    email: string;
    dataUltimoLogin: string;
    ativo: boolean;
    dataInclusao: string;
    dataAlteracao: string;
  };
  token: string;
  dataExpiracao: string;
}
