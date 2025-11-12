using AutoMapper;
using CofrinhoSenhas.Aplicacao.DTOs;
using CofrinhoSenhas.Aplicacao.Interfaces;
using CofrinhoSenhas.Dominio.Entidades;
using CofrinhoSenhas.Dominio.Interfaces;

namespace CofrinhoSenhas.Aplicacao.Servicos
{
    /// <summary>
    /// Serviço responsável pela lógica de negócio de categorias
    /// </summary>
    public class CategoriaServico : ICategoriaServico
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IMapper _mapeador;

        public CategoriaServico(ICategoriaRepositorio categoriaRepositorio, IMapper mapeador)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapeador = mapeador;
        }

        /// <summary>
        /// Busca todas as categorias cadastradas
        /// </summary>
        public async Task<IEnumerable<CategoriaDTO>> ObterTodosAsync()
        {
            var categorias = await _categoriaRepositorio.ObterCategoriasAsync();
            return _mapeador.Map<IEnumerable<CategoriaDTO>>(categorias);
        }

        /// <summary>
        /// Busca todas as categorias de um usuário específico
        /// </summary>
        /// <param name="idUsuario">ID do usuário</param>
        public async Task<IEnumerable<CategoriaDTO>> ObterCategoriasPorUsuarioAsync(int idUsuario)
        {
            var categorias = await _categoriaRepositorio.ObterCategoriasPorUsuarioAsync(idUsuario);
            return _mapeador.Map<IEnumerable<CategoriaDTO>>(categorias);
        }

        /// <summary>
        /// Busca uma categoria pelo ID
        /// </summary>
        /// <param name="id">ID da categoria</param>
        public async Task<CategoriaDTO?> ObterPorIdAsync(int id)
        {
            var categoria = await _categoriaRepositorio.ObterPorIdAsync(id);
            return categoria != null ? _mapeador.Map<CategoriaDTO>(categoria) : null;
        }

        /// <summary>
        /// Cria uma nova categoria no sistema
        /// </summary>
        /// <param name="criarCategoriaDto">Dados da nova categoria</param>
        public async Task<CategoriaDTO> CriarAsync(CriarCategoriaDTO criarCategoriaDto)
        {
            var categoria = new Categoria(
                criarCategoriaDto.Nome,
                criarCategoriaDto.Descricao,
                criarCategoriaDto.IdUsuario
            );

            var categoriaCriada = await _categoriaRepositorio.CriarAsync(categoria);
            return _mapeador.Map<CategoriaDTO>(categoriaCriada);
        }

        /// <summary>
        /// Atualiza uma categoria existente
        /// </summary>
        /// <param name="id">ID da categoria</param>
        /// <param name="atualizarCategoriaDto">Novos dados da categoria</param>
        public async Task<CategoriaDTO> AtualizarAsync(int id, AtualizarCategoriaDTO atualizarCategoriaDto)
        {
            var categoria = await _categoriaRepositorio.ObterPorIdAsync(id);
            if (categoria == null)
                throw new ArgumentException("Categoria não encontrada");

            categoria.Atualizar(atualizarCategoriaDto.Nome, atualizarCategoriaDto.Descricao);
            
            var categoriaAtualizada = await _categoriaRepositorio.AtualizarAsync(categoria);
            return _mapeador.Map<CategoriaDTO>(categoriaAtualizada);
        }

        /// <summary>
        /// Remove uma categoria do sistema
        /// </summary>
        /// <param name="id">ID da categoria</param>
        public async Task RemoverAsync(int id)
        {
            var categoria = await _categoriaRepositorio.ObterPorIdAsync(id);
            if (categoria == null)
                throw new ArgumentException("Categoria não encontrada");

            await _categoriaRepositorio.RemoverAsync(categoria);
        }
    }
}

