using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class TypeEventRepository : IBaseRepository<TypeEvent>
    {
        private readonly ApplicationDbContext appDbCon;
        public TypeEventRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(TypeEvent entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(TypeEvent entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<TypeEvent> Get(Guid id)
        {
            return await appDbCon.TypeEvents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<TypeEvent> Select()
        {
            return appDbCon.TypeEvents;
        }

        public async Task<TypeEvent> Update(TypeEvent entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
