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
        public Stop[] ResNameStops = new Stop[0];
        public void OnGet(int IdTransport)
        {
            using (Context db = new Context())
            {
                Relationship_between_transports_and_stops[] IdStopsArray = db.Relationships.ToArray();
                ResIdStops = (from Stp in IdStopsArray where (FilterStops1(Stp, IdTransport)) select Stp).ToArray();
                Stop[] StopArray = db.Stops.ToArray();
                foreach(Relationship_between_transports_and_stops stops in ResIdStops)
                {
                    ResNameStops = (from Stops in StopArray where (FilterStops2(Stops,stops.IdStops)) select Stops).ToArray();
                }
            }
        }

        private bool FilterStops1(Relationship_between_transports_and_stops stp, int searchingStops)
        {
            bool isFinded = stp.IdTransport.Equals(searchingStops);
            return isFinded;
        }
        private bool FilterStops2(Stop stop,int searchingStop)
        {
            bool isFinded = searchingStop.Equals(stop.Id);
            return isFinded;
        }
    }
}
