using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class DronRepository : IBaseRepository<Dron>
    {
        private readonly ApplicationDbContext appDbCon;
        public DronRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(Dron entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Dron entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<Dron> Get(Guid id)
        {
            return await appDbCon.Drons.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Dron> Select()
        {
            return appDbCon.Drons;
        }

        public async Task<Dron> Update(Dron entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
