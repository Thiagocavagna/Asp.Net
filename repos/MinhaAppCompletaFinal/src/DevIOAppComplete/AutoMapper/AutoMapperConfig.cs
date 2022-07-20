using AutoMapper;
using DevIO.Business.Models;
using DevIOAppComplete.ViewModels;

namespace DevIOAppComplete.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        //criar mapeamento
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap(); //reversemap para fazer o caminho inverso
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();

        }
    }
}
