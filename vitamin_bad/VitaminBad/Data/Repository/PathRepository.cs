using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;
using Path = VitaminBad.Domain.Entity.Path;

namespace VitaminBad.Data.Repository
{
    public class PathRepository : IBaseRepository<Path>
    {
        private readonly ApplicationDbContext appDbCon;
        public PathRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(Path entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Path entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<Path> Get(Guid id)
        {
            return await appDbCon.Paths.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Path> Select()
        {
            return appDbCon.Paths;
        }

        public async Task<Path> Update(Path entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
