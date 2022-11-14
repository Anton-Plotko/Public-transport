using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Public_transport.Models;

namespace Public_transport.Pages
{
    public class All_StopsModel : PageModel
    {
        public Stop[] ResAllStops = new Stop[0];
        public void OnGet()
        {
            using (Context db = new Context())
            {
                Stop[] AllStopArray = db.Stops.ToArray();
                ResAllStops = AllStopArray;
            }
        }
    }
}
