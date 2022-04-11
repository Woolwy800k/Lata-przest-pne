using Microsoft.EntityFrameworkCore;
using Lata_przestępne.Models;

namespace Lata_przestępne.Data
{
    public class ContextofYears : DbContext
    {
        public ContextofYears(DbContextOptions options) : base(options) { }
        public DbSet<Lataprzestepne> Lataprzestepne { get; set; }

    }
}
