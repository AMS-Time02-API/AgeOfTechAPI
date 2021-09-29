using System.Collections.Generic;
using System.Threading.Tasks;
using AgeOfTechAPI.Data;
using AgeOfTechAPI.Interface;
using Microsoft.EntityFrameworkCore;

namespace AgeOfTechAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }
        public void Add(T entity)
        {
            this.context.Add(entity);
        }

        public void Delete(int delete)
        {
            delete = 0;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.context.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await this.context.SaveChangesAsync()) > 0;
        }


       

        public async Task<T> GetById(string id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }
    }
}