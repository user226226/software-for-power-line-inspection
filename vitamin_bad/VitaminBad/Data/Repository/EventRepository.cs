using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class EventRepository : IBaseRepository<Event>
    {
        private readonly ApplicationDbContext appDbCon;
        public EventRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(Event entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Event entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<Event> Get(Guid id)
        {
            return await appDbCon.Events.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Event> Select()
        {
            return appDbCon.Events;
        }

        public async Task<Event> Update(Event entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
