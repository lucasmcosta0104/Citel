using AutoMapper;
using Citel.Models;
using Citel.Application.Commands;
using Citel.Application.Models;
using Citel.Application.Notifications;

namespace Citel.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile() 
        {
            CreateMap<CadastraProdutoCommand, Produto>()
                .ForMember(x => x.Id, op => op.Ignore());

            CreateMap<CadastraProdutoCommand, ProdutoCriadoNotification>()
                .ForMember(x => x.DataCriado, op => op.MapFrom(y => DateTime.Now));

            CreateMap<Produto, ProdutoExcluidoNotification>()
                .ForMember(x => x.DataExcluido, op => op.MapFrom(y => DateTime.Now));

            CreateMap<EditaProdutoCommand, Produto>();

            CreateMap<EditaProdutoCommand, EditaProdutoNotification>()
                .ForMember(x => x.DataEdicao, op => op.MapFrom(y => DateTime.Now));

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(x => x.Categoria, op => op.MapFrom(y => y.Categoria.Nome));

        }
    }
}
