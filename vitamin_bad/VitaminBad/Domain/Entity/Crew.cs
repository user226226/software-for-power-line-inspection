using System.Text.Json.Serialization;

namespace VitaminBad.Domain.Entity
{
    public class Crew
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Emploee>? Emploee { get; set; }
        public Guid? EventId { get; set; }
        [JsonIgnore]
        public Event? Event { get; set; }

    }
}
