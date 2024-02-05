using VitaminBad.Domain.Entity;

namespace VitaminBad.Domain.ViewModel
{
    public class EventViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateCreate { get; set; }
        public double Dolgota { get; set; }
        public double Shirota { get; set; }
        public string StatusName { get; set; }
        public string TypeEventName { get; set; }
        public string DroneName { get; set; }
        public string DroneModel { get; set; }
        public string DronePName { get; set;}
    }
}
