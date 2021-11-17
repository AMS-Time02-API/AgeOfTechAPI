using System.Threading.Tasks;
using AgeOfTechAPI.Entities;
using AgeOfTechAPI.Interface;
using AgeOfTechAPI.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgeOfTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public IRepository<Categoria> Repo { get; }
        private  IMapper Mapper {get;}
        public CategoriaController(IRepository<Categoria> repo, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entity = await this.Repo.GetAll();
            var results = this.Mapper.Map<CategoriaModel[]>(entity);
            return Ok(results);
        }

        [HttpGet("{CategoriaId}")]
        public async Task<IActionResult> GetById(string CategoriaId)
        {
            var entity = await this.Repo.GetById(CategoriaId);
            var results =this.Mapper.Map<CategoriaModel>(entity);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoriaModel categoria)
        {

            var cat = this.Mapper.Map<Categoria>(categoria);
            cat.Descricao = cat.Descricao.ToLower(); //Deixar a descrição tudo minúsculo!!!

            this.Repo.Add(cat);

            if (await this.Repo.SaveChangesAsync())
                return Created($"api/Categoria/{categoria.Id}", categoria);
            return BadRequest();
        }

         [HttpPut("{id}")]
          public async Task<IActionResult> Put(string id, CategoriaModel model)
        {
               var entity = await this.Repo.GetById(id);
               if (entity == null) return NotFound();
            
               this.Mapper.Map(model, entity);
               this.Repo.Update (entity);
               if (await this.Repo.SaveChangesAsync())
                   return Created($"api/Categoria/{model.Id}", this.Mapper.Map<CategoriaModel>(entity));
               return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(string id)
        {
            var entity = await this.Repo.GetById(id);
             if (entity == null) return NotFound();
                 
                 this.Repo.Delete(entity);    

             if (await this.Repo.SaveChangesAsync())
                  return Ok();

            return BadRequest();
        }



       

    }
}