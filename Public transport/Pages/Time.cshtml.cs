using Microsoft.AspNetCore.Mvc.RazorPages;
using Public_transport.Models;


namespace Public_transport.Pages
{
    public class TimeModel : PageModel
    {
        public Relationship_between_transports_and_stops[] Resalt = new Relationship_between_transports_and_stops[0];
        public string TimeMonFri="";
        public string TimeSaSu="";
        public string? NameT;
        public string? NameS;
        public string? Type;
        public void OnGet(int IdStops,int IdTransport,string NameTransport,string NameStop,string TypeTransport)
        {
            using (Context db = new Context())
            {
                NameT = NameTransport;
                NameS = NameStop;
                Type = TypeTransport;
                Relationship_between_transports_and_stops[] IdStopsArray = db.Relationships.ToArray();
                Resalt = (from Stp in IdStopsArray where (FilterStops1(Stp, IdTransport)) select Stp).ToArray();
                foreach (Relationship_between_transports_and_stops resalt in Resalt)
                {
                    if (resalt.IdTransport==IdTransport&&resalt.IdStops==IdStops)
                    {
                        TimeMonFri = resalt.TimeMonFri;
                        TimeSaSu = resalt.TimeSaSu;
                    }
                }
            }    
        }
        private bool FilterStops1(Relationship_between_transports_and_stops stp, int searchingStops)
        {
            bool isFinded = stp.IdTransport.Equals(searchingStops);
            return isFinded;
        }
    }
}
