namespace Public_transport.Models
{
    public class Relationship_between_transports_and_stops
    {
        public int Id { get; set; }
        public int IdTransport { get; set; }
        public int IdStops { get; set; }
    }
}
