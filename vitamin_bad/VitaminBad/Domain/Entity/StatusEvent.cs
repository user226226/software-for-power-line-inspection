using System.Text.Json.Serialization;

namespace VitaminBad.Domain.Entity
{
    public class StatusEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? EventId { get; set; }
        [JsonIgnore]
        public Event? Event { get; set; }
    }
}
