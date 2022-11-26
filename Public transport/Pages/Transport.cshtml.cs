using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Public_transport.Models;

namespace Public_transport.Pages
{
    public class TransportModel : PageModel
    {
        public RelationshipBetweenTransportsAndStops[] ResId = new RelationshipBetweenTransportsAndStops[0];
        public List<PublicTransport> ResName = new List<PublicTransport>();
        public int ID;
        public string? Name;
        public void OnGet(int IdStops,string NameStop)
        {
            ID = IdStops;
            Name = NameStop;
            using (Context db = new Context())
            {
                RelationshipBetweenTransportsAndStops[] IdStopsArray = db.Relationships.ToArray();
                ResId = (from Stp in IdStopsArray where (FilterStops1(Stp, IdStops)) select Stp).ToArray();
                PublicTransport[] TransportArray = db.Transports.ToArray();
                foreach (RelationshipBetweenTransportsAndStops Stops in ResId)
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
        private bool FilterStops1(RelationshipBetweenTransportsAndStops stp, int searchingStops)
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
