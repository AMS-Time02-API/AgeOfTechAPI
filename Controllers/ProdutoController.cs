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

    public class ProdutoController : ControllerBase
    {
        public IRepository<Produto> Repo { get; }
        public IMapper Mapper { get; }

        public ProdutoController(IRepository<Produto> repo, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Repo = repo;

        }

        [HttpGet]

        public async Task<ActionResult> Get() 
        {
            var entity = await this.Repo.GetAll();
            var results = this.Mapper.Map<ProdutoModel[]>(entity);

            return Ok (results);
        }

          [HttpPost]
        public async Task<IActionResult> Post(ProdutoModel produtoModel)
        {

            var entity = this.Mapper.Map<Produto>(produtoModel);
            entity.Descricao = entity.Descricao.ToLower(); //Deixar a descrição tudo minúsculo!!!

            this.Repo.Add(entity);

            if (await this.Repo.SaveChangesAsync())
                return Created($"api/Produto/{produtoModel.Id}", produtoModel);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ProdutoModel model)
        {
            var entity = await this.Repo.GetById(id);
            if (entity == null) return NotFound();
            
            this.Mapper.Map(model, entity);
            this.Repo.Update (entity);
            if (await this.Repo.SaveChangesAsync())
                return Created($"api/Produto/{model.Id}", this.Mapper.Map<ProdutoModel>(entity));
            return BadRequest();
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> delete(string id, ProdutoModel model)
        {
            var entity = await this.Repo.GetById(id);
             if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Repo.Delete();    

             if (await this.Repo.SaveChangesAsync())
                return Created($"/api/produto/{model.Id}", this.Mapper.Map<ProdutoModel>(entity));

            return BadRequest();
        
        }
    }
}