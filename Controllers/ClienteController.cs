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
    public class ClienteController : ControllerBase
    {
        public IMapper Mapper { get; }
        public IRepository<Cliente> Repo { get; }
         public ClienteController(IRepository<Cliente> repo, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entity = await this.Repo.GetAll();
            var results = this.Mapper.Map<ClienteModel[]>(entity);
            return Ok(results);
        }

         [HttpGet("{ClienteId}")]
        public async Task<IActionResult> GetById(string ClienteId)
        {
            var entity = await this.Repo.GetById(ClienteId);
            var results =this.Mapper.Map<ClienteModel>(entity);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteModel clienteModel)
        {

            var entity = this.Mapper.Map<Cliente>(clienteModel);
            entity.Nome = entity.Nome.ToLower(); //Deixar a descrição tudo minúsculo!!!

            this.Repo.Add(entity);

            if (await this.Repo.SaveChangesAsync())
                return Created($"api/Cliente/{clienteModel.Id}", clienteModel);
            return BadRequest();
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ClienteModel model)
        {
            var entity = await this.Repo.GetById(id);
            if (entity == null) return NotFound();
            
            this.Mapper.Map(model, entity);
            this.Repo.Update (entity);
            if (await this.Repo.SaveChangesAsync())
                return Created($"api/Cliente/{model.Id}", this.Mapper.Map<ClienteModel>(entity));
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