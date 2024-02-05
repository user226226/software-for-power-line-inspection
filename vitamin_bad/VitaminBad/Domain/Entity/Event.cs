namespace VitaminBad.Domain.Entity
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
        public Coordinate? Coordinate { get; set; }  
        public StatusEvent? StatusEvent { get; set; }
        public TypeEvent? TypeEvent { get; set; } 
        public Dron? Dron { get; set; }
        public Crew? Crew { get; set; }
    }
}
