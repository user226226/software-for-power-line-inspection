namespace VitaminBad.Domain.Entity
{
    public class Path
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Id_Drone { get; set; }
        public Dron? Dron { get; set; }
        public List<Coordinate>? Coordinates { get; set; }
    }
}
