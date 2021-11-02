using AgeOfTechAPI.Entities;
using AgeOfTechAPI.Model;
using AutoMapper;
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
            //CreateMap<Endereco, EnderecoModel>().ReverseMap();
            
        }
    }
}