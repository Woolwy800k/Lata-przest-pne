using Lata_przestępne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Lata_przestępne.Models;

namespace Lata_przestępne.Pages

{
    public class Zapisane : PageModel
    {
        public Lataprzestepne Lataprzestepne { get; set; }

        public List<string[]> wiersz;


        public void OnGet()
        {

            var Data = HttpContext.Session.GetString("CheckedList");
            if (Data != null)
                wiersz = JsonConvert.DeserializeObject<List<string[]>>(Data);
        }
    }
}