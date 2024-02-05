using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VitaminBad.Domain.Entity;
using VitaminBad.Domain.ViewModel;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetEventByCoorController : ControllerBase
    {
        private readonly IEventService _dts;
        public GetEventByCoorController(IEventService d)
        {
            _dts = d;
        }
        [HttpPost(Name = "EventByCoor")]
        public async Task<Event> GetCoordinates(CoorditateViewModel cvm)
        {
            var r = await _dts.GetByCoordinate(cvm);
            return r.Data;
        }

    }
}
