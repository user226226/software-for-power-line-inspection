using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class EmploeeRepository : IBaseRepository<Emploee>
    {
        private readonly ApplicationDbContext appDbCon;
        public EmploeeRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(Emploee entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Emploee entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<Emploee> Get(Guid id)
        {
            return await appDbCon.Emploees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Emploee> Select()
        {
            return appDbCon.Emploees;
        }

        public async Task<Emploee> Update(Emploee entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
