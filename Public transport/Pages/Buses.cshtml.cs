using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Public_transport.Models;

namespace Public_transport.Pages
{
    public class BusesModel : PageModel
    {
        public PublicTransport[] ResBus = new PublicTransport[0];

        public void OnGet(string? Type)
        {

            using (Context db = new Context())
            {
                PublicTransport[] BusArray = db.Transports.ToArray();
                ResBus = (from Bus in BusArray where (FilterTransport(Bus, Type ?? "")) select Bus).ToArray();
            }
        }

        private bool FilterTransport(PublicTransport bus, string searchingBus)
        {
            bool isFinded = (bus.Type?.Contains(searchingBus) ?? false);
            return isFinded;
        }
    }
}
