using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lata_przestępne.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Lata_przestępne.Data;
using Microsoft.EntityFrameworkCore;

namespace Lata_przestępne.Pages
{
        public class IndexModel : PageModel
        {
            private readonly ILogger<IndexModel> _logger;
            private readonly ContextofYears _context;

            [BindProperty]
            public Lataprzestepne Lataprzestepne { get; set; }

            public string[] Arr;
            public IList<Lataprzestepne> LLataprzestepne { get; set; }

            public IndexModel(ILogger<IndexModel> logger, ContextofYears context)
            {
                _logger = logger;
                _context = context;
            }

            public void OnGet()
            {

            }

            public IActionResult OnPost()
            {
                if (ModelState.IsValid)
                {
                Lataprzestepne.Data = DateTime.Now;

                    Arr = new string[4];
                    Arr[0] = Lataprzestepne.Imie;
                    Arr[1] = Lataprzestepne.Nazwisko;
                    Arr[2] = Lataprzestepne.Rok.ToString();
                    Arr[3] = Lataprzestepne.Przestepnosc(Lataprzestepne.Rok);


                    List<string[]> List;

                    var Data = HttpContext.Session.GetString("CheckedList");
                    if (Data != null)
                        List = JsonConvert.DeserializeObject<List<string[]>>(Data);
                    else
                        List = new List<string[]>();

                    List.Add(Arr);
                    HttpContext.Session.SetString("CheckedList", JsonConvert.SerializeObject(List));

                    LLataprzestepne = _context.Lataprzestepne.ToList();
                    _context.Lataprzestepne.Add(Lataprzestepne);
                    _context.SaveChanges();

                }
                return Page();
            }
        }
    
}