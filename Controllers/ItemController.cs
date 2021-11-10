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
    public class ItemController : ControllerBase
    {
         public IMapper Mapper { get; }
         public IRepository<Item> Repo { get; }
         public ItemController(IRepository<Item> repo, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Repo = repo;
        }

         [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var entity = await this.Repo.GetAll();
            var results = this.Mapper.Map<ItemModel[]>(entity);

            return Ok (results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ItemModel itemModel)
        {

            var entity = this.Mapper.Map<Item>(itemModel);
            
            this.Repo.Add(entity);

            if (await this.Repo.SaveChangesAsync())
                return Created($"api/Item/{itemModel.Id}", itemModel);
            return BadRequest();
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ItemModel model)
        {
            var entity = await this.Repo.GetById(id);
            if (entity == null) return NotFound();
            
            this.Mapper.Map(model, entity);
            this.Repo.Update (entity);
            if (await this.Repo.SaveChangesAsync())
                return Created($"api/Item/{model.Id}", this.Mapper.Map<ItemModel>(entity));
            return BadRequest();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> delete(string id, ItemModel model)
        {
            var entity = await this.Repo.GetById(id);
             if (entity == null) return NotFound();
            this.Mapper.Map(model, entity);
            this.Repo.Delete();    

             if (await this.Repo.SaveChangesAsync())
                return Created($"/api/Item/{model.Id}", this.Mapper.Map<ItemModel>(entity));

            return BadRequest();
        
        }


       
    }
}