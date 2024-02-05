using VitaminBad.Domain;
using VitaminBad.Domain.Entity;
using VitaminBad.Domain.ViewModel;

namespace VitaminBad.Service.Interfaces
{
    public interface ICoordinateService
    {
        Task<BaseResponse<string>> Create(Coordinate c);
        Task<BaseResponse<List<CoorditateViewModel>>> GetAll();

    }
}
