namespace VitaminBad.Domain.Entity
{
    public class Emploee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Dolzhnost { get; set; }
        public bool Sex { get; set; }
        public Guid? CrewId { get; set; }
        public Crew? Crew { get; set; }

    }
}
