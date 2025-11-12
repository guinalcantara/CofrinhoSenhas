using AutoMapper;
using CofrinhoSenhas.Aplicacao.DTOs;
using CofrinhoSenhas.Aplicacao.Interfaces;
using CofrinhoSenhas.Dominio.Entidades;
using CofrinhoSenhas.Dominio.Interfaces;

namespace CofrinhoSenhas.Aplicacao.Servicos
{
    /// <summary>
    /// Serviço responsável pela lógica de negócio de etiquetas
    /// </summary>
    public class EtiquetaServico : IEtiquetaServico
    {
        private readonly IEtiquetaRepositorio _etiquetaRepositorio;
        private readonly IMapper _mapeador;

        public EtiquetaServico(IEtiquetaRepositorio etiquetaRepositorio, IMapper mapeador)
        {
            _etiquetaRepositorio = etiquetaRepositorio;
            _mapeador = mapeador;
        }

        /// <summary>
        /// Busca todas as etiquetas cadastradas
        /// </summary>
        public async Task<IEnumerable<EtiquetaDTO>> ObterTodosAsync()
        {
            var etiquetas = await _etiquetaRepositorio.ObterEtiquetasAsync();
            return _mapeador.Map<IEnumerable<EtiquetaDTO>>(etiquetas);
        }

        /// <summary>
        /// Busca todas as etiquetas de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        public async Task<IEnumerable<EtiquetaDTO>> ObterEtiquetasPorUsuarioAsync(int idUsuario)
        {
            var etiquetas = await _etiquetaRepositorio.ObterEtiquetasPorUsuarioAsync(idUsuario);
            return _mapeador.Map<IEnumerable<EtiquetaDTO>>(etiquetas);
        }

        /// <summary>
        /// Busca uma etiqueta pelo ID
        /// </summary>
        /// <param name="id">ID da etiqueta</param>
        public async Task<EtiquetaDTO?> ObterPorIdAsync(int id)
        {
            var etiqueta = await _etiquetaRepositorio.ObterPorIdAsync(id);
            return etiqueta != null ? _mapeador.Map<EtiquetaDTO>(etiqueta) : null;
        }

        /// <summary>
        /// Cria uma nova etiqueta no sistema
        /// </summary>
        /// <param name="criarEtiquetaDto">Dados da nova etiqueta</param>
        public async Task<EtiquetaDTO> CriarAsync(CriarEtiquetaDTO criarEtiquetaDto)
        {
            var etiqueta = new Etiqueta(
                criarEtiquetaDto.Nome,
                criarEtiquetaDto.Descricao,
                criarEtiquetaDto.IdUsuario
            );

            var etiquetaCriada = await _etiquetaRepositorio.CriarAsync(etiqueta);
            return _mapeador.Map<EtiquetaDTO>(etiquetaCriada);
        }

        /// <summary>
        /// Atualiza uma etiqueta existente
        /// </summary>
        /// <param name="id">ID da etiqueta</param>
        /// <param name="atualizarEtiquetaDto">Novos dados da etiqueta</param>
        public async Task<EtiquetaDTO> AtualizarAsync(int id, AtualizarEtiquetaDTO atualizarEtiquetaDto)
        {
            var etiqueta = await _etiquetaRepositorio.ObterPorIdAsync(id);
            if (etiqueta == null)
                throw new ArgumentException("Etiqueta não encontrada");

            etiqueta.Atualizar(atualizarEtiquetaDto.Nome, atualizarEtiquetaDto.Descricao);
            
            var etiquetaAtualizada = await _etiquetaRepositorio.AtualizarAsync(etiqueta);
            return _mapeador.Map<EtiquetaDTO>(etiquetaAtualizada);
        }

        /// <summary>
        /// Remove uma etiqueta do sistema
        /// </summary>
        /// <param name="id">ID da etiqueta</param>
        public async Task RemoverAsync(int id)
        {
            var etiqueta = await _etiquetaRepositorio.ObterPorIdAsync(id);
            if (etiqueta == null)
                throw new ArgumentException("Etiqueta não encontrada");

            await _etiquetaRepositorio.RemoverAsync(etiqueta);
        }
    }
}

