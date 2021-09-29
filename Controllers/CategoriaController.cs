using System.Threading.Tasks;
using AgeOfTechAPI.Entities;
using AgeOfTechAPI.Interface;
using AgeOfTechAPI.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AgeOfTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public IRepository<Categoria> repo { get; }
        private readonly IMapper mapper;
        public CategoriaController(IRepository<Categoria> repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entity = await this.repo.GetAll();
            var results = this.mapper.Map<CategoriaModel[]>(entity);
            return Ok(results);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CategoriaModel categoria)
        {

            var cat = this.mapper.Map<Categoria>(categoria);
            cat.Descricao = cat.Descricao.ToLower(); //Deixar a descrição tudo minúsculo!!!

            this.repo.Add(cat);

            if (await this.repo.SaveChangesAsync())
                return Created($"api/Categoria/{categoria.Id}", categoria);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, CategoriaModel model)
        {
            var entity = await this.repo.GetById(id);
            if (entity == null) return NotFound();

            this.mapper.Map(model, entity);
            this.repo.Update(entity);
            if (await this.repo.SaveChangesAsync())
                return Created($"/api/categoria/{model.Id}", this.mapper.Map<CategoriaModel>(entity));

            return BadRequest();

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> delete(string id, CategoriaModel model)
        {
            var entity = await this.repo.GetById(id);
             if (entity == null) return NotFound();
            this.mapper.Map(model, entity);
            this.repo.Delete();    

             if (await this.repo.SaveChangesAsync())
                return Created($"/api/categoria/{model.Id}", this.mapper.Map<CategoriaModel>(entity));

            return BadRequest();         
        }



    }
}