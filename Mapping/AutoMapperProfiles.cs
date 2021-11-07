using AgeOfTechAPI.Entities;
using AgeOfTechAPI.Model;
using AutoMapper;
using Entities;
using Model;

namespace AgeOfTechAPI.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Categoria, CategoriaModel>().ReverseMap();  
            CreateMap<Produto, ProdutoModel>().ReverseMap();
            CreateMap<Cliente, ClienteModel>().ReverseMap();
            CreateMap<Endereco, EnderecoModel>().ReverseMap();
            CreateMap<Status, StatusModel>().ReverseMap();
            CreateMap<Pedido, PedidoModel>().ReverseMap();
            CreateMap<Item, ItemModel>().ReverseMap();
            
        }
    }
}