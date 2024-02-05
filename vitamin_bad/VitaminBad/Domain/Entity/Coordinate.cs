using Microsoft.VisualBasic;
using System.Text.Json.Serialization;

namespace VitaminBad.Domain.Entity
{
    public class Coordinate
    {
        public Guid Id { get; set; }
        public double Dolgota { get; set; }
        public double Shirota { get; set; }
        public Guid? EventId {  get; set; }
        [JsonIgnore]
        public Event? Event { get; set; }
        [JsonIgnore]
        public Guid? PathId {  get; set; }
        [JsonIgnore]
        public Path? Path { get; set; }

    }
}
