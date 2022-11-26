using Microsoft.AspNetCore.Mvc.RazorPages;
using Public_transport.Models;


namespace Public_transport.Pages
{
    public class TimeModel : PageModel
    {
        public RelationshipBetweenTransportsAndStops[] Resalt = new RelationshipBetweenTransportsAndStops[0];
        public string TimeMonFri="";
        public string TimeSaSu="";
        public string? NameT;
        public string? NameS;
        public string? Type;
        public int IDS;
        public int IDT;
        public void OnGet(int IdStops,int IdTransport,string NameTransport,string NameStop,string TypeTransport)
        {
            using (Context db = new Context())
            {
                NameT = NameTransport;
                NameS = NameStop;
                Type = TypeTransport;
                IDS = IdStops;
                IDT = IdTransport;
                RelationshipBetweenTransportsAndStops[] IdStopsArray = db.Relationships.ToArray();
                Resalt = (from Stp in IdStopsArray where (FilterStops1(Stp, IdTransport)) select Stp).ToArray();
                foreach (RelationshipBetweenTransportsAndStops resalt in Resalt)
                {
                    if (resalt.IdTransport==IdTransport&&resalt.IdStops==IdStops)
                    {
                        TimeMonFri = resalt.TimeMonFri;
                        TimeSaSu = resalt.TimeSaSu;
                    }
                }
            }    
        }
        private bool FilterStops1(RelationshipBetweenTransportsAndStops stp, int searchingStops)
        {
            bool isFinded = stp.IdTransport.Equals(searchingStops);
            return isFinded;
        }
    }
}
