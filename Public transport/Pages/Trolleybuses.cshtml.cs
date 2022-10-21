using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Public_transport.Models;

namespace Public_transport.Pages
{
    public class TrolleybusesModel : PageModel
    {
        public PublicTransport[] ResTroll = new PublicTransport[0];
      
        public void OnGet(string? Type)
        {
            
            using (Context db = new Context()) 
            {
                PublicTransport[]TrollArray=db.Transports.ToArray();
                ResTroll = (from Trl in TrollArray where (FilterTransport(Trl, Type ?? ""))select Trl).ToArray();
            }
        }

        private bool FilterTransport(PublicTransport trl, string searchingTroll) 
        {
            bool isFinded = (trl.Type?.Contains(searchingTroll) ?? false);
            return isFinded;
        }
    }
}
