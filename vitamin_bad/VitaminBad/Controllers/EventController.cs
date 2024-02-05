using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VitaminBad.Domain.Entity;
using VitaminBad.Domain.ViewModel;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController: ControllerBase
    {
        private readonly IEventService _dts;
        private long UserId => long.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public EventController(IEventService d)
        {
            _dts = d;
        }
        [HttpPost(Name = "Event")]
        public async Task<string> PostEvent(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "Data/PhotoNew/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
            }
            else
            {
                return "Try again";
            }
            //TODO: Загрузка в модель
            // Имитация выходных данных с модели
            var res = new EventViewModel()
            {
                Name = "01JUP27",
                Description = "Grow",
                DateCreate = "2024.04.04",
                Dolgota = 54.919,
                Shirota = 52.319,
                StatusName = "Unresolve",
                TypeEventName = "Broken balk",
                DroneName = "Mavric 56Y",
                DroneModel = "DJMavric 5",
                DronePName = "Canon D600"
            };
            var r = await _dts.Create(res);
            // Имитация выходных данных с модели
            var res2 = new EventViewModel()
            {
                Name = "02IOP21",
                Description = "GMo",
                DateCreate = "2023.02.14",
                Dolgota = 54.927,
                Shirota = 52.322,
                StatusName = "В процессе",
                TypeEventName = "Поврежденная опора",
                DroneName = "Mavric 96Y",
                DroneModel = "DJMavric 9",
                DronePName = "Canon D600"
            };
            var r2 = await _dts.Create(res2);
            return r.Data;
        }
    }

}
