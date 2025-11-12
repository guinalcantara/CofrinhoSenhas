using AutoMapper;
using CofrinhoSenhas.Aplicacao.DTOs;
using CofrinhoSenhas.Aplicacao.Interfaces;
using CofrinhoSenhas.Dominio.Entidades;
using CofrinhoSenhas.Dominio.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace CofrinhoSenhas.Aplicacao.Servicos
{
    /// <summary>
    /// Serviço responsável pela lógica de negócio de usuários
    /// </summary>
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapeador;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio, IMapper mapeador)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapeador = mapeador;
        }

        /// <summary>
        /// Busca todos os usuários cadastrados
        /// </summary>
        public async Task<IEnumerable<UsuarioDTO>> ObterTodosAsync()
        {
            IEnumerable<Usuario> usuarios = await _usuarioRepositorio.ObterUsuariosAsync();
            return _mapeador.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }

        /// <summary>
        /// Busca um usuário pelo ID
        /// </summary>
        /// <param name="id">ID do usuário</param>
        public async Task<UsuarioDTO?> ObterPorIdAsync(int id)
        {
            Usuario? usuario = await _usuarioRepositorio.ObterPorIdAsync(id);
            return usuario != null ? _mapeador.Map<UsuarioDTO>(usuario) : null;
        }

        /// <summary>
        /// Busca um usuário pelo email
        /// </summary>
        /// <param name="email">Email do usuário</param>
        public async Task<UsuarioDTO?> ObterPorEmailAsync(string email)
        {
            Usuario? usuario = await _usuarioRepositorio.ObterPorEmailAsync(email);
            return usuario != null ? _mapeador.Map<UsuarioDTO>(usuario) : null;
        }

        /// <summary>
        /// Cria um novo usuário no sistema
        /// </summary>
        /// <param name="criarUsuarioDto">Dados do novo usuário</param>
        public async Task<UsuarioDTO> CriarAsync(CriarUsuarioDTO criarUsuarioDto)
        {
            (string hash, string sal) = CriarHashSenha(criarUsuarioDto.Senha);
            
            Usuario usuario = new Usuario(
                criarUsuarioDto.Nome,
                criarUsuarioDto.Email,
                hash,
                sal
            );

            Usuario usuarioCriado = await _usuarioRepositorio.CriarAsync(usuario);
            return _mapeador.Map<UsuarioDTO>(usuarioCriado);
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="atualizarUsuarioDto">Novos dados do usuário</param>
        public async Task<UsuarioDTO> AtualizarAsync(int id, AtualizarUsuarioDTO atualizarUsuarioDto)
        {
            Usuario? usuario = await _usuarioRepositorio.ObterPorIdAsync(id);
            if (usuario == null)
                throw new ArgumentException("Usuário não encontrado");

            usuario.Atualizar(atualizarUsuarioDto.Nome, atualizarUsuarioDto.Email);
            
            Usuario usuarioAtualizado = await _usuarioRepositorio.AtualizarAsync(usuario);
            return _mapeador.Map<UsuarioDTO>(usuarioAtualizado);
        }

        /// <summary>
        /// Remove um usuário do sistema
        /// </summary>
        /// <param name="id">ID do usuário</param>
        public async Task RemoverAsync(int id)
        {
            Usuario? usuario = await _usuarioRepositorio.ObterPorIdAsync(id);
            if (usuario == null)
                throw new ArgumentException("Usuário não encontrado");

            await _usuarioRepositorio.RemoverAsync(usuario);
        }

        /// <summary>
        /// Autentica um usuário no sistema verificando email e senha
        /// </summary>
        /// <param name="loginDto">Email e senha do usuário</param>
        public async Task<UsuarioDTO?> AutenticarAsync(LoginDTO loginDto)
        {
            Usuario? usuario = await _usuarioRepositorio.ObterPorEmailAsync(loginDto.Email);
            if (usuario == null || !VerificarSenha(loginDto.Senha, usuario.HashSenha, usuario.SaltSenha))
                return null;

            usuario.DefinirUltimoLogin();
            await _usuarioRepositorio.AtualizarAsync(usuario);

            return _mapeador.Map<UsuarioDTO>(usuario);
        }

        /// <summary>
        /// Altera a senha de um usuário
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="senhaAtual">Senha atual do usuário</param>
        /// <param name="novaSenha">Nova senha desejada</param>
        public async Task<bool> AlterarSenhaAsync(int id, string senhaAtual, string novaSenha)
        {
            Usuario? usuario = await _usuarioRepositorio.ObterPorIdAsync(id);
            if (usuario == null)
                return false;

            if (!VerificarSenha(senhaAtual, usuario.HashSenha, usuario.SaltSenha))
                return false;

            (string hash, string sal) = CriarHashSenha(novaSenha);
            usuario.AtualizarSenha(hash, sal);
            
            await _usuarioRepositorio.AtualizarAsync(usuario);
            return true;
        }

        /// <summary>
        /// Cria um hash seguro da senha usando HMACSHA512
        /// </summary>
        /// <param name="senha">Senha em texto</param>
        /// <returns>Hash e salt da senha</returns>
        private static (string hash, string sal) CriarHashSenha(string senha)
        {
            using HMACSHA512 hmac = new HMACSHA512();
            string sal = Convert.ToBase64String(hmac.Key);
            string hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(senha)));
            return (hash, sal);
        }

        /// <summary>
        /// Verifica se uma senha corresponde ao hash armazenado
        /// </summary>
        /// <param name="senha">Senha em texto</param>
        /// <param name="hashArmazenado">Hash armazenado no banco</param>
        /// <param name="salArmazenado">Salt armazenado no banco</param>
        /// <returns>True se a senha está correta, False caso contrário</returns>
        private static bool VerificarSenha(string senha, string hashArmazenado, string salArmazenado)
        {
            byte[] bytesSal = Convert.FromBase64String(salArmazenado);
            using HMACSHA512 hmac = new HMACSHA512(bytesSal);
            string hashComputado = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(senha)));
            return hashComputado == hashArmazenado;
        }
    }
}

