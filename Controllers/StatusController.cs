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
    public class StatusController : ControllerBase
    {
        public IRepository<Status> Repo { get; }
        public IMapper Mapper { get; }

        public StatusController(IRepository<Status> repo, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Repo = repo;

        }

         [HttpGet]

        public async Task<IActionResult> Get() 
        {
            var entity = await this.Repo.GetAll();
            var results = this.Mapper.Map<StatusModel[]>(entity);

            return Ok (results);
        }

        [HttpGet("{StatusId}")]
        public async Task<IActionResult> GetById(string StatusId)
        {
            var entity = await this.Repo.GetById(StatusId);
            var results =this.Mapper.Map<StatusModel>(entity);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StatusModel model)
        {

            var entity = this.Mapper.Map<Status>(model);
            entity.Estado = entity.Estado.ToLower(); //Deixar a descrição tudo minúsculo!!!

            this.Repo.Add(entity);

            if (await this.Repo.SaveChangesAsync())
                return Created($"api/status/{model.Id}", model);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, StatusModel model)
        {
            var entity = await this.Repo.GetById(id);
            if (entity == null) return NotFound();
            
            this.Mapper.Map(model, entity);
            this.Repo.Update (entity);
            if (await this.Repo.SaveChangesAsync())
                return Created($"api/Status/{model.Id}", this.Mapper.Map<StatusModel>(entity));
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