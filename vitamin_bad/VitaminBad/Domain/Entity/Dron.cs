using System.Text.Json.Serialization;

namespace VitaminBad.Domain.Entity
{
    public class Dron
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public Guid? EventId { get; set; }
        [JsonIgnore]
        public Event? Event { get; set; }
        public PNagruzka? PNagruzka { get; set; }


    }
}
