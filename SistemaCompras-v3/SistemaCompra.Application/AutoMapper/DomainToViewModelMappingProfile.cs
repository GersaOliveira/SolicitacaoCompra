using AutoMapper;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using SistemaCompra.Application.SolicitacaoCompra.Query;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using CompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoAgg.Produto, ObterProdutoViewModel>()
                .ForMember(d => d.Preco, o => o.MapFrom(src => src.Preco));

            CreateMap<CompraAgg.SolicitacaoCompra, ObterSolicitacaoCompraQueryViewModel>()
           .ForMember(dest => dest.UsuarioSolicitante, opt => opt.MapFrom(src => src.UsuarioSolicitante))
           .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.NomeFornecedor))
           .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens))
           .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
           .ForMember(dest => dest.Situacao, opt => opt.MapFrom(src => src.Situacao))
           .ForMember(dest => dest.CondicaoPagamento, opt => opt.MapFrom(src => src.CondicaoPagamento))
           .ForMember(dest => dest.TotalGeral, opt => opt.MapFrom(src => src.TotalGeral));
        }
    }
}
