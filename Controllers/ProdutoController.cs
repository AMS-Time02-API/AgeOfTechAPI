using System.Threading.Tasks;
using AgeOfTechAPI.Entities;
using AgeOfTechAPI.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public IRepository<Produto> repo { get; }
        public IMapper mapper { get; }
        public ProdutoController(IRepository<Produto> repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entity = await this.repo.GetAll();
            var results = this.mapper.Map<ProdutoModel[]>(entity);
            
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoModel produtoModel)
        {
            var entity =  this.mapper.Map<Produto>(produtoModel);
            entity.Descricao = entity.Descricao.ToLower();
            
            this.repo.Add(entity);

            if (await this.repo.SaveChangesAsync())
                 return Created($"api/Produto/{produtoModel.Id}", produtoModel);
            
            return BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ProdutoModel model)
        {
             var entity = await this.repo.GetById(id);
             if (entity == null) return NotFound();
                   this.mapper.Map(model, entity);
                   this.repo.Update (entity);
            
             if (await this.repo.SaveChangesAsync())
                 return Created($"api/Produto/{model.Id}", this.mapper.Map<ProdutoModel>(entity));
            
             return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, ProdutoModel model)
        {
             var entity = await this.repo.GetById(id);
             if (entity == null) return NotFound();
                  this.mapper.Map(model, entity);
                  this.repo.Delete();    

             if (await this.repo.SaveChangesAsync())
                  return Created($"/api/Produto/{model.Id}", this.mapper.Map<ProdutoModel>(entity));

             return BadRequest();  
        }
    }
}