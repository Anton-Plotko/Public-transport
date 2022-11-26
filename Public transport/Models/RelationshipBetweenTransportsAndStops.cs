namespace Public_transport.Models
{
    public class RelationshipBetweenTransportsAndStops
    {
        public int Id { get; set; }
        public int IdTransport { get; set; }
        public int IdStops { get; set; }
        public string TimeMonFri { get; set; }
        public string TimeSaSu { get; set; }
    }
}
