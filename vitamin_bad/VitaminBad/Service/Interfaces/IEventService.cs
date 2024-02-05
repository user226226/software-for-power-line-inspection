using VitaminBad.Domain.Entity;
using VitaminBad.Domain;
using VitaminBad.Domain.ViewModel;

namespace VitaminBad.Service.Interfaces
{
    public interface IEventService
    {
        Task<BaseResponse<string>> Create(EventViewModel c);
        Task<BaseResponse<List<Event>>> FindById(Guid guid);
        Task<BaseResponse<Event>> GetByCoordinate(CoorditateViewModel c);

    }
}
