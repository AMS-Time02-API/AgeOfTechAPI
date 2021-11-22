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
    
    public class EnderecoController : ControllerBase
    { 
         public IRepository<Endereco> Repo { get; }
        public IMapper Mapper { get; }

        public EnderecoController(IRepository<Endereco> repo, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var entity = await this.Repo.GetAll();
            var results = this.Mapper.Map<EnderecoModel[]>(entity);

            return Ok (results);
        }

        [HttpGet("{EnderecoId}")]
        public async Task<IActionResult> GetById(string EnderecoId)
        {
            var entity = await this.Repo.GetById(EnderecoId);
            var results =this.Mapper.Map<EnderecoModel>(entity);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EnderecoModel enderecoModel)
        {

            var entity = this.Mapper.Map<Endereco>(enderecoModel);
            entity.Logradouro = entity.Logradouro.ToLower(); //Deixar a descrição tudo minúsculo!!!
            entity.Bairro = entity.Bairro.ToLower(); //Deixar a descrição tudo minúsculo!!!
            entity.Cidade = entity.Cidade.ToLower(); //Deixar a descrição tudo minúsculo!!!
            entity.Estado = entity.Estado.ToLower(); //Deixar a descrição tudo minúsculo!!!


            this.Repo.Add(entity);

            if (await this.Repo.SaveChangesAsync())
                return Created($"api/Endereco/{enderecoModel.Id}", enderecoModel);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, EnderecoModel model)
        {
            var entity = await this.Repo.GetById(id);
            if (entity == null) return NotFound();
            
            this.Mapper.Map(model, entity);
            this.Repo.Update (entity);
            if (await this.Repo.SaveChangesAsync())
                return Created($"api/Endereco/{model.Id}", this.Mapper.Map<EnderecoModel>(entity));
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