using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class CrewRepository : IBaseRepository<Crew>
    {
        private readonly ApplicationDbContext appDbCon;
        public CrewRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(Crew entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Crew entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<Crew> Get(Guid id)
        {
            return await appDbCon.Crews.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Crew> Select()
        {
            return appDbCon.Crews;
        }

        public async Task<Crew> Update(Crew entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
