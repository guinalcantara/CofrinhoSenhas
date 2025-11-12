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
    /// Serviço responsável pela lógica de negócio de senhas
    /// </summary>
    public class SenhaServico : ISenhaServico
    {
        private readonly ISenhaRepositorio _senhaRepositorio;
        private readonly IEtiquetaRepositorio _etiquetaRepositorio;
        private readonly IMapper _mapeador;
        private const string ChaveCriptografia = "CofrinhoSenhas2024ChaveSecreta123456789012";

        public SenhaServico(ISenhaRepositorio senhaRepositorio, IEtiquetaRepositorio etiquetaRepositorio, IMapper mapeador)
        {
            _senhaRepositorio = senhaRepositorio;
            _etiquetaRepositorio = etiquetaRepositorio;
            _mapeador = mapeador;
        }

        /// <summary>
        /// Busca todas as senhas cadastradas
        /// </summary>
        public async Task<IEnumerable<SenhaDTO>> ObterTodosAsync()
        {
            IEnumerable<Senha> senhas = await _senhaRepositorio.ObterSenhasAsync();
            return _mapeador.Map<IEnumerable<SenhaDTO>>(senhas);
        }

        /// <summary>
        /// Busca todas as senhas de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        public async Task<IEnumerable<SenhaDTO>> ObterSenhasPorUsuarioAsync(int idUsuario)
        {
            IEnumerable<Senha> senhas = await _senhaRepositorio.ObterSenhasPorUsuarioAsync(idUsuario);
            return _mapeador.Map<IEnumerable<SenhaDTO>>(senhas);
        }

        /// <summary>
        /// Busca todas as senhas de uma categoria específica
        /// </summary>
        /// <param name="idCategoria">ID da categoria</param>
        public async Task<IEnumerable<SenhaDTO>> ObterSenhasPorCategoriaAsync(int idCategoria)
        {
            IEnumerable<Senha> senhas = await _senhaRepositorio.ObterSenhasPorCategoriaAsync(idCategoria);
            return _mapeador.Map<IEnumerable<SenhaDTO>>(senhas);
        }

        /// <summary>
        /// Busca uma senha pelo ID
        /// </summary>
        /// <param name="id">ID da senha</param>
        public async Task<SenhaDTO?> ObterPorIdAsync(int id)
        {
            Senha? senha = await _senhaRepositorio.ObterPorIdAsync(id);
            return senha != null ? _mapeador.Map<SenhaDTO>(senha) : null;
        }

        /// <summary>
        /// Busca uma senha pelo ID e retorna com o valor descriptografado
        /// </summary>
        /// <param name="id">ID da senha</param>
        public async Task<SenhaDescriptografadaDTO?> ObterDescriptografadaPorIdAsync(int id)
        {
            Senha? senha = await _senhaRepositorio.ObterPorIdAsync(id);
            if (senha == null)
                return null;

            SenhaDescriptografadaDTO senhaDescriptografada = _mapeador.Map<SenhaDescriptografadaDTO>(senha);
            senhaDescriptografada.Senha = DescriptografarSenha(senha.SenhaCriptografada);
            
            return senhaDescriptografada;
        }

        /// <summary>
        /// Cria uma nova senha no sistema
        /// </summary>
        /// <param name="criarSenhaDto">Dados da nova senha</param>
        public async Task<SenhaDTO> CriarAsync(CriarSenhaDTO criarSenhaDto)
        {
            string senhaCriptografada = CriptografarSenha(criarSenhaDto.Senha);
            
            Senha senha = new Senha(
                criarSenhaDto.Titulo,
                criarSenhaDto.Url,
                criarSenhaDto.Login,
                senhaCriptografada,
                criarSenhaDto.IdUsuario,
                criarSenhaDto.Descricao,
                criarSenhaDto.IdCategoria
            );

            // Adicionar etiquetas se fornecidas
            if (criarSenhaDto.IdEtiquetas.Any())
            {
                foreach (int idEtiqueta in criarSenhaDto.IdEtiquetas)
                {
                    Etiqueta? etiqueta = await _etiquetaRepositorio.ObterPorIdAsync(idEtiqueta);
                    if (etiqueta != null)
                    {
                        senha.Etiquetas.Add(etiqueta);
                    }
                }
            }

            Senha senhaCriada = await _senhaRepositorio.CriarAsync(senha);
            return _mapeador.Map<SenhaDTO>(senhaCriada);
        }

        /// <summary>
        /// Atualiza uma senha existente
        /// </summary>
        /// <param name="id">ID da senha</param>
        /// <param name="atualizarSenhaDto">Novos dados da senha</param>
        public async Task<SenhaDTO> AtualizarAsync(int id, AtualizarSenhaDTO atualizarSenhaDto)
        {
            Senha? senha = await _senhaRepositorio.ObterPorIdAsync(id);
            if (senha == null)
                throw new ArgumentException("Senha não encontrada");

            string senhaCriptografada = !string.IsNullOrEmpty(atualizarSenhaDto.Senha) 
                ? CriptografarSenha(atualizarSenhaDto.Senha) 
                : senha.SenhaCriptografada;

            senha.Atualizar(
                atualizarSenhaDto.Titulo,
                atualizarSenhaDto.Url,
                atualizarSenhaDto.Login,
                senhaCriptografada,
                atualizarSenhaDto.Descricao,
                atualizarSenhaDto.IdCategoria
            );

            // Atualizar etiquetas
            senha.Etiquetas.Clear();
            if (atualizarSenhaDto.IdEtiquetas.Any())
            {
                foreach (int idEtiqueta in atualizarSenhaDto.IdEtiquetas)
                {
                    Etiqueta? etiqueta = await _etiquetaRepositorio.ObterPorIdAsync(idEtiqueta);
                    if (etiqueta != null)
                    {
                        senha.Etiquetas.Add(etiqueta);
                    }
                }
            }

            Senha senhaAtualizada = await _senhaRepositorio.AtualizarAsync(senha);
            return _mapeador.Map<SenhaDTO>(senhaAtualizada);
        }

        /// <summary>
        /// Remove uma senha do sistema
        /// </summary>
        /// <param name="id">ID da senha</param>
        public async Task RemoverAsync(int id)
        {
            Senha? senha = await _senhaRepositorio.ObterPorIdAsync(id);
            if (senha == null)
                throw new ArgumentException("Senha não encontrada");

            await _senhaRepositorio.RemoverAsync(senha);
        }
        
        /// <summary>
        /// Criptografa uma senha usando AES
        /// </summary>
        /// <param name="senha">Senha em texto</param>
        /// <returns>Senha criptografada em Base64</returns>
        private static string CriptografarSenha(string senha)
        {
            using Aes aes = Aes.Create();

            // Força chave de 32 bytes
            byte[] chaveBytes = new byte[32];
            Encoding.UTF8.GetBytes(ChaveCriptografia, 0, Math.Min(ChaveCriptografia.Length, 32), chaveBytes, 0);
            aes.Key = chaveBytes;

            aes.IV = new byte[16]; // IV zerado

            using ICryptoTransform criptografador = aes.CreateEncryptor();
            byte[] bytesSenha = Encoding.UTF8.GetBytes(senha);
            byte[] bytesCriptografados = criptografador.TransformFinalBlock(bytesSenha, 0, bytesSenha.Length);

            return Convert.ToBase64String(bytesCriptografados);
        }

        /// <summary>
        /// Descriptografa uma senha usando AES
        /// </summary>
        /// <param name="senhaCriptografada">Senha criptografada em Base64</param>
        /// <returns>Senha em texto</returns>
        private static string DescriptografarSenha(string senhaCriptografada)
        {
            using Aes aes = Aes.Create();

            byte[] chaveBytes = new byte[32];
            Encoding.UTF8.GetBytes(ChaveCriptografia, 0, Math.Min(ChaveCriptografia.Length, 32), chaveBytes, 0);
            aes.Key = chaveBytes;

            aes.IV = new byte[16]; // IV zerado

            using ICryptoTransform descriptografador = aes.CreateDecryptor();
            byte[] bytesCriptografados = Convert.FromBase64String(senhaCriptografada);
            byte[] bytesDescriptografados = descriptografador.TransformFinalBlock(bytesCriptografados, 0, bytesCriptografados.Length);

            return Encoding.UTF8.GetString(bytesDescriptografados);
        }

    }
}

