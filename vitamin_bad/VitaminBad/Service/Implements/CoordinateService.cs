using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain;
using VitaminBad.Domain.Entity;
using VitaminBad.Domain.ViewModel;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Service.Implements
{
    public class CoordinateService : ICoordinateService
    {
        private readonly IBaseRepository<Coordinate> _coordinateRepository;

        public CoordinateService(IBaseRepository<Coordinate> coordinateRepository)
        {
            _coordinateRepository = coordinateRepository;
        }
        public Task<BaseResponse<string>> Create(Coordinate c)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<List<CoorditateViewModel>>> GetAll()
        {
            try
            {
                var coordinates = await _coordinateRepository.Select().Include(x=>x.Event).ToListAsync();
                List<CoorditateViewModel> coorditateViewModels = new List<CoorditateViewModel>();
                foreach (var coorditateViewModel in coordinates)
                {
                  
                    coorditateViewModels.Add(new CoorditateViewModel()
                    {
                        Info = coorditateViewModel.Event.Name,
                        Coordinates = new double[2] { coorditateViewModel.Dolgota, coorditateViewModel.Shirota }
                    });
                }
                return new BaseResponse<List<CoorditateViewModel>>()
                {
                    Data = coorditateViewModels,
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<List<CoorditateViewModel>>();
                z.Description = $"[Get Coordinate]:{ex.Message}";

                return z;

            }
        }
    }
}
