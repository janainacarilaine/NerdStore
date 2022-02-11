using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(d => d.Altura, option => option.MapFrom(x => x.Dimensoes.Altura))
                .ForMember(d => d.Largura, option => option.MapFrom(x => x.Dimensoes.Largura))
                .ForMember(d => d.Profundidade, option => option.MapFrom(x => x.Dimensoes.Profundidade));

            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
