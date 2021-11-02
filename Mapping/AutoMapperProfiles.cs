using AgeOfTechAPI.Entities;
using AgeOfTechAPI.Model;
using AutoMapper;

namespace AgeOfTechAPI.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Categoria, CategoriaModel>().ReverseMap();  
            CreateMap<Produto, ProdutoModel>().ReverseMap();
            
        }
    }
}