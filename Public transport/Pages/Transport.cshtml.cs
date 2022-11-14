using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Public_transport.Models;

namespace Public_transport.Pages
{
    public class TransportModel : PageModel
    {
        public Relationship_between_transports_and_stops[] ResId = new Relationship_between_transports_and_stops[0];
        public List<PublicTransport> ResName = new List<PublicTransport>();
        public int ID;
        public void OnGet(int IdStops)
        {
            ID = IdStops;
            using (Context db = new Context())
            {
                Relationship_between_transports_and_stops[] IdStopsArray = db.Relationships.ToArray();
                ResId = (from Stp in IdStopsArray where (FilterStops1(Stp, IdStops)) select Stp).ToArray();
                PublicTransport[] TransportArray = db.Transports.ToArray();
                foreach (Relationship_between_transports_and_stops Stops in ResId)
                {
                    foreach (PublicTransport stop in TransportArray)
                    {
                        if (FilterStops2(Stops.IdTransport, stop.Id))
                        {
                            ResName.Add(stop);
                            break;
                        }

                    }
                }
                
            }
        }
        private bool FilterStops1(Relationship_between_transports_and_stops stp, int searchingStops)
        {
            bool isFinded = stp.IdStops.Equals(searchingStops);
            return isFinded;
        }
        private bool FilterStops2(int stop, int searchingStop)
        {
            bool isFinded = stop.Equals(searchingStop);
            return isFinded;
        }
    }
}
