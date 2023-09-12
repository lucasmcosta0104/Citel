using AutoMapper;
using Citel.Application.Commands;
using Citel.Application.Models;
using Citel.Application.Notifications;

namespace ProdutoApi.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile() 
        {
            CreateMap<CadastraCategoriaCommand, Categoria>()
                .ForMember(x => x.Id, op => op.Ignore())
                .ForMember(x => x.Produto, op => op.Ignore());

            CreateMap<CadastraCategoriaCommand, CategoriaCriadoNotification>()
                .ForMember(x => x.DataCriado, op => op.MapFrom(y => DateTime.Now));

            CreateMap<Categoria, CategoriaExcluidoNotification>()
                .ForMember(x => x.DataExcluido, op => op.MapFrom(y => DateTime.Now));

            CreateMap<EditaCategoriaCommand, Categoria>();

            CreateMap<EditaCategoriaCommand, EditaCategoriaNotification>()
                .ForMember(x => x.DataEdicao, op => op.MapFrom(y => DateTime.Now));
        }
    }
}
