using AutoMapper;
using Dev.AppMvc.ViewModels;
using MinhaAp.Busines.Models;

namespace Dev.AppMvc.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();

        }
    }
}
