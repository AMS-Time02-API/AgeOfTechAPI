using System.Threading.Tasks;
using AgeOfTechAPI.Interface;
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        public IMapper Mapper { get; }
        public IRepository<Perfil> Repo { get; }
       public PerfilController(IRepository<Perfil> repo, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Repo = repo;
        }

       [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entity = await this.Repo.GetAll();
            var results = this.Mapper.Map<PerfilModel[]>(entity);
            return Ok(results);
        }
    }
}