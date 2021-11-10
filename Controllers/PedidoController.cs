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
    public class PedidoController : ControllerBase
    {
        public IMapper Mapper { get; }
        public IRepository<Pedido> Repo { get; }
        public PedidoController(IRepository<Pedido> repo, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Repo = repo;
        }

       [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var entity = await this.Repo.GetAll();
            var results = this.Mapper.Map<PedidoModel[]>(entity);

            return Ok (results);
        }

         [HttpPost]
        public async Task<IActionResult> Post(PedidoModel pedidoModel)
        {

            var entity = this.Mapper.Map<Pedido>(pedidoModel);
           
            this.Repo.Add(entity);
            
            if (await this.Repo.SaveChangesAsync())
                return Created($"api/Pedido/{pedidoModel.Id}", pedidoModel);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, PedidoModel model)
        {
            var entity = await this.Repo.GetById(id);
            if (entity == null) return NotFound();
            
            this.Mapper.Map(model, entity);
            this.Repo.Update (entity);
            if (await this.Repo.SaveChangesAsync())
                return Created($"api/Pedido/{model.Id}", this.Mapper.Map<PedidoModel>(entity));
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(string id, PedidoModel model)
        {
            var entity = await this.Repo.GetById(id);
             if (entity == null) return NotFound();
                  this.Mapper.Map(model, entity);
                 this.Repo.Delete(entity);    

             if (await this.Repo.SaveChangesAsync())
                return Created($"/api/Pedido/{model.Id}", this.Mapper.Map<PedidoModel>(entity));

            return BadRequest();
        
        }
    }
}