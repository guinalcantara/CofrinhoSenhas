using AutoMapper;
using CofrinhoSenhas.Aplicacao.DTOs;
using CofrinhoSenhas.Dominio.Entidades;

namespace CofrinhoSenhas.Aplicacao.Mapeamentos
{
    public class MapeamentoDTO : Profile
    {
        public MapeamentoDTO()
        {
            CreateMap<Usuario, UsuarioDTO>();
            
            CreateMap<Categoria, CategoriaDTO>()
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nome : string.Empty));
            
            CreateMap<Senha, SenhaDTO>()
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nome : string.Empty))
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria != null ? src.Categoria.Nome : string.Empty))
                .ForMember(dest => dest.Etiquetas, opt => opt.MapFrom(src => src.Etiquetas.Select(e => e.Nome).ToList()));

            CreateMap<Senha, SenhaDescriptografadaDTO>()
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria != null ? src.Categoria.Nome : string.Empty))
                .ForMember(dest => dest.Etiquetas, opt => opt.MapFrom(src => src.Etiquetas.Select(e => e.Nome).ToList()))
                .ForMember(dest => dest.Senha, opt => opt.Ignore());

            CreateMap<Etiqueta, EtiquetaDTO>()
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nome : string.Empty));

            CreateMap<LogEvento, LogEventoDTO>()
                .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nome : string.Empty));
        }
    }
}

