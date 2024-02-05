using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain.Entity;

namespace VitaminBad.Data.Repository
{
    public class CoordinateRepository : IBaseRepository<Coordinate>
    {
        private readonly ApplicationDbContext appDbCon;
        public CoordinateRepository(ApplicationDbContext app)
        {
            appDbCon = app;
        }
        public async Task<bool> Create(Coordinate entity)
        {
            await appDbCon.AddAsync(entity);
            await appDbCon.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Coordinate entity)
        {
            appDbCon.Remove(entity);
            appDbCon.SaveChanges();
            return true;
        }

        public async Task<Coordinate> Get(Guid id)
        {
            return await appDbCon.Coordinates.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Coordinate> Select()
        {
            return appDbCon.Coordinates;
        }

        public async Task<Coordinate> Update(Coordinate entity)
        {
            appDbCon.Update(entity);
            await appDbCon.SaveChangesAsync();
            return entity;
        }
    }
}
