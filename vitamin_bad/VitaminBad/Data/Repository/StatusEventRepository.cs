using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class StatusEventRepository : IBaseRepository<StatusEvent>
    {
        private readonly ApplicationDbContext appDbCon;
        public StatusEventRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(StatusEvent entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(StatusEvent entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<StatusEvent> Get(Guid id)
        {
            return await appDbCon.StatusEvents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<StatusEvent> Select()
        {
            return appDbCon.StatusEvents;
        }

        public async Task<StatusEvent> Update(StatusEvent entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
