using Microsoft.EntityFrameworkCore;
using VitaminBad.Data.Interface;
using VitaminBad.Domain;
using VitaminBad.Domain.Entity;
using VitaminBad.Domain.ViewModel;
using VitaminBad.Service.Interfaces;

namespace VitaminBad.Service.Implements
{
    public class EventService : IEventService
    {
        private readonly IBaseRepository<Event> _eventRepository;
        private readonly IBaseRepository<Coordinate> _coordinateRepository;
        private readonly IBaseRepository<TypeEvent> _typeEventRepository;
        private readonly IBaseRepository<StatusEvent> _statusEventRepository;
        private readonly IBaseRepository<Dron> _dronRepository;
        private readonly IBaseRepository<PNagruzka> _pNaRepository;

        public EventService(IBaseRepository<Event> eventRepository,
            IBaseRepository<Coordinate> coordinateRepository,
            IBaseRepository<TypeEvent> typeEventRepository,
            IBaseRepository<StatusEvent> statusEventRepository,
            IBaseRepository<Dron> dronRepository,
            IBaseRepository<PNagruzka> pNaRepository)
        {
            _eventRepository = eventRepository;
            _coordinateRepository = coordinateRepository;
            _typeEventRepository = typeEventRepository;
            _statusEventRepository = statusEventRepository;
            _dronRepository = dronRepository;
            _pNaRepository = pNaRepository;
        }

        public async Task<BaseResponse<string>> Create(EventViewModel c)
        {
            try
            {
                var eventDb = await _eventRepository.Select().Where(x => x.Name == c.Name).FirstOrDefaultAsync();
                var coordinate = await _coordinateRepository.Select().Where(x => x.Shirota == c.Shirota && x.Dolgota == c.Dolgota).FirstOrDefaultAsync();
                if (coordinate == null)
                {
                    await _coordinateRepository.Create(new Coordinate { Dolgota = c.Dolgota, Shirota = c.Shirota });
                    coordinate = await _coordinateRepository.Select().Where(x => x.Shirota == c.Shirota && x.Dolgota == x.Dolgota).FirstOrDefaultAsync();
                }
                var statusEvent = await _statusEventRepository.Select().Where(x => x.Name == c.StatusName).FirstOrDefaultAsync();
                if (statusEvent == null)
                {
                    await _statusEventRepository.Create(new StatusEvent { Name = c.StatusName });
                    statusEvent = await _statusEventRepository.Select().Where(x => x.Name == c.StatusName).FirstOrDefaultAsync();
                }
                var typeEvent = await _typeEventRepository.Select().Where(x => x.Name == c.TypeEventName).FirstOrDefaultAsync();
                if (typeEvent == null)
                {
                    await _typeEventRepository.Create(new TypeEvent { Name = c.TypeEventName });
                    typeEvent = await _typeEventRepository.Select().Where(x => x.Name == c.TypeEventName).FirstOrDefaultAsync();
                }
                var drone = await _dronRepository.Select().Where(x => x.Name == c.DroneName && x.Model == c.DroneModel).FirstOrDefaultAsync();
                if (drone == null)
                {
                    var pNagruzka = await _pNaRepository.Select().Where(x => x.Name == c.DronePName).FirstOrDefaultAsync();
                    if(pNagruzka == null)
                    {
                        await _pNaRepository.Create(new PNagruzka() { Name = c.DronePName });
                        pNagruzka = await _pNaRepository.Select().Where(x => x.Name == c.DronePName).FirstOrDefaultAsync();
                    }
                    await _dronRepository.Create(new Dron { Name = c.DroneName, Model = c.DroneModel, PNagruzka = pNagruzka });
                    drone = await _dronRepository.Select().Where(x => x.Name == c.DroneName && x.Model == c.DroneModel).FirstOrDefaultAsync();
                }
                Event ev = new Event()
                {
                    Name = c.Name,
                    Description = c.Description,
                    DateCreate = DateTime.Parse(c.DateCreate),
                    Coordinate = coordinate,
                    StatusEvent = statusEvent,
                    TypeEvent = typeEvent,
                    Dron = drone
                };
                if (eventDb != null) {
                    await _eventRepository.Update(ev);
                    return new BaseResponse<string>()
                    {
                        Data = String.Format("updated event {0}", ev.Name),
                        StatusCode = StatusCode.OK
                    };
                }
                else
                {
                    await _eventRepository.Create(ev);
                    return new BaseResponse<string>()
                    {
                        Data=String.Format( "Added event {0}", ev.Name),
                        StatusCode = StatusCode.OK
                    };
                }

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<string>();
                z.Description = $"[Create Event]:{ex.Message}";

                return z;
            }
        }

        public Task<BaseResponse<List<Event>>> FindById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<Event>> GetByCoordinate(CoorditateViewModel c)
        {
            try
            {
                var coordinate = await _coordinateRepository.Select()
                    .Where(x => x.Shirota == c.Coordinates[1] && x.Dolgota == c.Coordinates[0])
                    .FirstOrDefaultAsync();
                if (coordinate == null)
                {
                    return new BaseResponse<Event>()
                    {
                        Data = new Event(),
                        StatusCode = StatusCode.OK
                    };
                }
                var events = await _eventRepository.Select()
                    .Where(x => x.Coordinate == coordinate)
                    .Include(x=>x.Coordinate)
                    .Include(x=>x.StatusEvent)
                    .Include(x=> x.TypeEvent)
                    .Include(x=> x.Dron).ThenInclude(x=>x.PNagruzka)
                    .Include(x=> x.Crew)
                    .FirstOrDefaultAsync();
                if (events == null)
                {
                    return new BaseResponse<Event>()
                    {
                        Data = new Event(),
                        StatusCode = StatusCode.OK
                    };
                }
                return new BaseResponse<Event>()
                {
                    Data = events,
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<Event>();
                z.Description = $"[Create Event]:{ex.Message}";

                return z;
            }
        }
    }
}
