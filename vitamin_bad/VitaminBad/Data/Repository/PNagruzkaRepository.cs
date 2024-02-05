using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class PNagruzkaRepository : IBaseRepository<PNagruzka>
    {
        private readonly ApplicationDbContext appDbCon;
        public PNagruzkaRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(PNagruzka entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(PNagruzka entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<PNagruzka> Get(Guid id)
        {
            return await appDbCon.PNagruzkas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<PNagruzka> Select()
        {
            return appDbCon.PNagruzkas;
        }

        public async Task<PNagruzka> Update(PNagruzka entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
