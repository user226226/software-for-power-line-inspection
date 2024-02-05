using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VitaminBad.Domain.Entity;
using VitaminBad.Domain.ViewModel;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoordinatesController : ControllerBase
    {
        private readonly ICoordinateService _dts;
        private long UserId => long.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public CoordinatesController(ICoordinateService d)
        {
            _dts = d;
        }
        [HttpGet(Name = "Coordinates")]
        public async Task<List<CoorditateViewModel>> GetCoordinates()
        {
            var r = await _dts.GetAll();
            return r.Data;
        }

    }
    
}