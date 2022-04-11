using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lata_przestępne.Data;
using Lata_przestępne.Models;

namespace Lata_przestępne.Pages
{
    public class Ostatnio_wyszukane : PageModel
    {
        private readonly ContextofYears _context;

        public IList<Lataprzestepne> LLataPrzestępne { get; set; }

        public Ostatnio_wyszukane(ContextofYears context)
        {
            _context = context;
        }

        public void OnGet()
        {
            LLataPrzestępne = _context.Lataprzestepne.OrderByDescending(wiersz => wiersz.Data).Take(20).ToList();
        }

        public IActionResult OnPostDeleteRecord(int RecordId)
        {
            _context.Remove(_context.Lataprzestepne.Single(wiersz => wiersz.Id == RecordId));
            _context.SaveChanges();
            return RedirectToPage("./Ostatnio wyszukane");
        }
    }
}
