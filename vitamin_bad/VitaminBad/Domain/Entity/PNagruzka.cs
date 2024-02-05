using System.Text.Json.Serialization;

namespace VitaminBad.Domain.Entity
{
    public class PNagruzka
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Dron? Dron { get; set; }
        public Guid? DronId { get; set; }
    }
}
