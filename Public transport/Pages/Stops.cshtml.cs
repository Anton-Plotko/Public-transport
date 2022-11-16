using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Public_transport.Models;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

namespace Public_transport.Pages
{
    public class StopsModel : PageModel
    {
        public Relationship_between_transports_and_stops[] ResIdStops = new Relationship_between_transports_and_stops[0];
        public List<Stop> ResNameStops = new List<Stop>();
        public string? Name; 
        public string? Type; 
        public void OnGet(int IdTransport,string NameTransport,string TypeTransport)
        {
            using (Context db = new Context())
            {
                Name=NameTransport;
                Type=TypeTransport;
                Relationship_between_transports_and_stops[] IdStopsArray = db.Relationships.ToArray();
                ResIdStops = (from Stp in IdStopsArray where (FilterStops1(Stp, IdTransport)) select Stp).ToArray();
                Stop[] StopArray = db.Stops.ToArray();
                foreach (Relationship_between_transports_and_stops Stops in ResIdStops)
                {
                    foreach (Stop stop in StopArray)
                    {
                        if (FilterStops2(Stops.IdStops, stop.Id))
                        {
                            ResNameStops.Add(stop);
                            break;
                        }
                        
                    }
                }
                
            }
        }
        private bool FilterStops1(Relationship_between_transports_and_stops stp, int searchingStops)
        {
            bool isFinded = stp.IdTransport.Equals(searchingStops);
            return isFinded;
        }
        private bool FilterStops2(int stop,int searchingStop)
        {
            bool isFinded = stop.Equals(searchingStop);
            return isFinded;
        }
    }
}
